    public static string GetFormDigest(Uri webUri, string userName, string password)
    {
       var claimsHelper = new MsOnlineClaimsHelper(webUri, userName, password);
       var endpointUri = new Uri(webUri,"/_api/contextinfo");
       var request = (HttpWebRequest)WebRequest.Create(endpointUri);
       request.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
       request.Method = WebRequestMethods.Http.Post;
       request.Accept = "application/json;odata=verbose";
       request.ContentType = "application/json;odata=verbose";
       request.ContentLength = 0;
       var fedAuthCookie = claimsHelper.CookieContainer.GetCookieHeader(webUri); //FedAuth are getting here
       request.Headers.Add(HttpRequestHeader.Cookie, fedAuthCookie); //only FedAuth cookie are provided here
       //request.CookieContainer = claimsHelper.CookieContainer;
       using (var response = (HttpWebResponse) request.GetResponse())
       {
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                    var content = streamReader.ReadToEnd();
                    var t = JToken.Parse(content);
                    return t["d"]["GetContextWebInformation"]["FormDigestValue"].ToString();
            }     
        }
    }
