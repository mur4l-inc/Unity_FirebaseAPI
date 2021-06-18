using System;
using System.Net;
using Scenes.Share;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Authentication
{
    public class EmailPasswordScript : MonoBehaviour
    {
        private string _apiKey = Config.ApiKey;

        public void SignUp()
        {
            var inputEmail = GameObject.Find("InputEmail").GetComponent<InputField>().text;
            var inputPassword = GameObject.Find("InputPassword").GetComponent<InputField>().text;
            var resultText = GameObject.Find("ResultText").GetComponent<Text>();

            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={_apiKey}";
            var requestBody = new FirebaseApi.EmailPasswordAuthRequest(inputEmail, inputPassword).ToJson();
            string response = wc.UploadString(new Uri(url), requestBody);
            Debug.Log(response);

            resultText.text = "サインアップに成功しました";
        }

        public void Login()
        {
            var inputEmail = GameObject.Find("InputEmail").GetComponent<InputField>().text;
            var inputPassword = GameObject.Find("InputPassword").GetComponent<InputField>().text;
            var resultText = GameObject.Find("ResultText").GetComponent<Text>();

            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={_apiKey}";
            var requestBody = new FirebaseApi.EmailPasswordAuthRequest(inputEmail, inputPassword).ToJson();
            string response = wc.UploadString(new Uri(url), requestBody);
            Debug.Log(response);

            resultText.text = "ログインに成功しました";
        }
    }
}