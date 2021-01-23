    var authHeader = WebOperationContext.Current.IncomingRequest.Headers.GetValues("Authorization");
                    if (authHeader == null || authHeader.Length == 0)
                    {
                        throw new WebFaultException(HttpStatusCode.Unauthorized);
                    }
                    NameValueCollection outgoingQueryString = HttpUtility.ParseQueryString(String.Empty);
    
                    var parts = authHeader[0].Split(' ');
                    if (parts[0] == "Bearer")
                    {
                        string token = parts[1];
    
                        outgoingQueryString.Add("token", token);
                        byte[] postdata = Encoding.ASCII.GetBytes(outgoingQueryString.ToString());
    
                        var result = string.Empty;
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(oauthConfiguration.Setting.CheckUrl);
                        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                        httpWebRequest.Method = "POST";
                        httpWebRequest.Headers.Add("Authorization", GetAuthorizationHeader(oauthConfiguration.Setting.ClientId, oauthConfiguration.Setting.ClientSecret));
                        httpWebRequest.ContentLength = postdata.Length;
                        using (Stream postStream = httpWebRequest.GetRequestStream())
                        {
                            postStream.Write(postdata, 0, postdata.Length);
                            postStream.Flush();
                            postStream.Close();
                        }
                        
                        var response = (HttpWebResponse)httpWebRequest.GetResponse();
                        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
