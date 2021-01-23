    //Need to create a class to deserialize the Json
    //Create this somewhere in your application
    public class OAuthErrorMsg
        {
            public string error { get; set; }
            public string error_description { get; set; }
            public string error_uri { get; set; }
        }
     //Need to make sure to include Newtonsoft.Json
     using Newtonsoft.Json;
     //Code for your object....
     private void login()
        {
            try
            {
                var state = _webServerClient.ExchangeUserCredentialForToken(
                    this.emailTextBox.Text, 
                    this.passwordBox.Password.Trim(), 
                    scopes: new string[] { "PublicProfile" });
                _accessToken = state.AccessToken;
                _refreshToken = state.RefreshToken;
            }
            catch (ProtocolException ex)
            {
                var webException = ex.InnerException as WebException;
                OAuthErrorMsg error = 
                    JsonConvert.DeserializeObject<OAuthErrorMsg>(
                    ExtractResponseString(webException));
                var errorMessage = error.error_description;
                //Now it's up to you how you process the errorMessage
            }
        }
        public static string ExtractResponseString(WebException webException)
        {
            if (webException == null || webException.Response == null)
                return null;
            var responseStream = 
                webException.Response.GetResponseStream() as MemoryStream;
            if (responseStream == null)
                return null;
            var responseBytes = responseStream.ToArray();
            var responseString = Encoding.UTF8.GetString(responseBytes);
            return responseString;
        }
