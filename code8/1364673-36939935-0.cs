    //Credentials validation
                var credentials = new CompanyCredential()
                {
                    Email = Constants.Username,
                    Password = Constants.Password
                };
                var jsonCredentials = JsonConvert.SerializeObject(credentials);
                var request = (HttpWebRequest) WebRequest.Create(new Uri(baseAddress, Constants.AuthorizeEndpoint));
                request.ContentType = "application/json";
                request.Method = "POST";
                var requestStream = request.GetRequestStreamAsync().Result;
                var streamWriter = new StreamWriter(requestStream);
                streamWriter.Write(jsonCredentials);
                streamWriter.Flush();
                try
                {
                    HttpWebResponse response = (HttpWebResponse) request.GetResponseAsync().Result;
                    if (response.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        authToken = response.Headers["Set-Cookie"];
                        tokenExpireDate = DateTime.ParseExact(response.Headers["Expires"], "yyyy-MM-dd HH:mm:ss,fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        //Authentication failed throw error
                        throw new HttpRequestException("Authentication failed");
                    }
                } catch (Exception e)
                {
                    Debug.WriteLine(string.Format("Warning: {0}", e.Message));
                }
