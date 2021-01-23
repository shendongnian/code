        private string GetFormDigest()
        {
            var webClient = new WebClient();
            webClient.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            webClient.Credentials = this.Credentials;
            webClient.Headers.Add(HttpRequestHeader.ContentType, String.Format("application/json;odata=nometadata"));
            webClient.Headers.Add(HttpRequestHeader.Accept, String.Format("application/json;odata=nometadata"));
            var uri = new Uri(this.SharepointBaseURL);
            var endpointUri = new Uri(uri, "_api/contextinfo");
            var result = webClient.UploadString(endpointUri, "POST");
            JToken t = JToken.Parse(result);
            //Use this if odata = nometadata
            return t["FormDigestValue"].ToString();
            //Use this if odata = verbose
            //return t["d"]["GetContextWebInformation"]["FormDigestValue"].ToString();
        }
