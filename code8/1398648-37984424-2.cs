       {
            var authority = "https://login.microsoftonline.com";
            var tenant = "common";
            var authorizeSuffix = "oauth2";
            var EndPointUrl = String.Format("{0}/{1}/{2}/authorize?", authority, tenant, authorizeSuffix);
            var clientId = "";
            var redirectURL = "http://localhost:56384/auth.aspx";         
            var parameters = new Dictionary<string, string>
                {
                    { "response_type", "code" },
                    { "client_id", clientId },
                    { "redirect_uri", redirectURL },
                    { "prompt", "login"}
                };
            var list = new List<string>();
            foreach (var parameter in parameters)
            {
                if (!string.IsNullOrEmpty(parameter.Value))
                    list.Add(string.Format("{0}={1}", parameter.Key, HttpUtility.UrlEncode(parameter.Value)));
            }
            var strParameters = string.Join("&", list);
            var requestURL=String.Concat(EndPointUrl,strParameters);
            Response.Redirect(requestURL);
            
        }
