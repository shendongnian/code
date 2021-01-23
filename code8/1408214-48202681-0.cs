                var filter = new HttpBaseProtocolFilter();
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.RevocationFailure);
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.RevocationInformationMissing);
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.WrongUsage);
                filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.IncompleteChain);
                Windows.Web.Http.HttpClient client = new Windows.Web.Http.HttpClient(filter);
                TimeSpan span = new TimeSpan(0, 0, 60);
                var cts = new CancellationTokenSource();
                cts.CancelAfter(span);
                var request = new Windows.Web.Http.HttpRequestMessage()
                {
                    RequestUri = new Uri(App.URL + "/oauth/token"),
                    Method = Windows.Web.Http.HttpMethod.Post,
                };
                //request.Properties. = span;
                string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Server_Username + ":" + Server_Password));
                var values = new Dictionary<string, string>
                    { { "grant_type", "password" },{ "username",  Uname}, { "password", Pwd }};
                var content = new HttpFormUrlEncodedContent(values);
                request.Headers.Add("Authorization", "Basic " + encoded);
                request.Content = content;
                User root = new User();
                using (Windows.Web.Http.HttpResponseMessage response = await client.SendRequestAsync(request).AsTask(cts.Token))
                {
                    HttpStatusCode = (int)response.StatusCode;
                    if (HttpStatusCode == (int)HttpCode.OK)
                    {
                        using (IHttpContent content1 = response.Content)
                        {
                            var jsonString = await content1.ReadAsStringAsync();
                            root = JsonConvert.DeserializeObject<User>(jsonString);
                            App.localSettings.Values["access_token"] = root.Access_token;
                            App.localSettings.Values["refresh_token"] = root.Refresh_token;
                            App.localSettings.Values["expires_in"] = root.Expires_in;
                            var json = JsonConvert.SerializeObject(root.Locations);
                            App.localSettings.Values["LocationList"] = json;
                            App.localSettings.Values["LoginUser"] = Uname;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
