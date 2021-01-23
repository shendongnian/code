       protected void Page_Load(object sender, EventArgs e)
        {
            var authority = "https://login.microsoftonline.com";
            var tenant = "common";
            var authorizeSuffix = "oauth2";
            var EndPointUrl = String.Format("{0}/{1}/{2}", authority, tenant, authorizeSuffix);
            var code = Request.QueryString["code"].ToString();
            var clientId = "";
            var resource = "https://graph.microsoft.com";
            var secrect = "";
            var redirectURL = "http://localhost:56384/auth.aspx";
            //Request access token
            var parameters = new Dictionary<string, string>
                {
                    { "resource", resource},
                    { "client_id", clientId },
                    { "code",  code},
                    { "grant_type", "authorization_code" },
                    { "redirect_uri", redirectURL},
                    { "client_secret",secrect}
                };
            var list = new List<string>();
            foreach (var parameter in parameters)
            {
                if (!string.IsNullOrEmpty(parameter.Value))
                    list.Add(string.Format("{0}={1}", parameter.Key, HttpUtility.UrlEncode(parameter.Value)));
            }
            var strParameters = string.Join("&", list);
            var content = new StringContent(strParameters, Encoding.GetEncoding("utf-8"), "application/x-www-form-urlencoded");
            
            var client = new HttpClient();
            var url = string.Format("{0}/token", EndPointUrl);
            var response = client.PostAsync(url, content).Result;
            var text = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject(text) as JObject;
            var AccessToken = result.GetValue("access_token").Value<string>();
            var RefreshToken = result.GetValue("refresh_token").Value<string>();
            Session["accessToken"] = AccessToken;
            Session["refreshToken"] = AccessToken;
          
            //add code read the user info from access token for login in
           
        }
