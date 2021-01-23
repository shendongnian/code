     using (var client = new HttpClient())
            {
                var uri = new Uri($"http://localhost:24728/ClientAuthorization?tourl={tourl}");
                var httpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"code", code},
                        {"redirect_uri", uri.AbsoluteUri},
                        {"grant_type","authorization_code"},
                        {"client_id", ClientStartupProfile.Client.ClientId},
                        {"client_secret", ClientStartupProfile.Client.Secret}
                    });
                var response = await client.PostAsync(ClientStartupProfile.AuthorizationServer.TokenUri, httpContent);
                var authorizationState = await response.Content.ReadAsAsync<AuthorizationState>();
                //判断access_token 是否获取成功
                if (!string.IsNullOrWhiteSpace(authorizationState.AccessToken))
                    Response.Cookies.Add(new System.Web.HttpCookie("access_token", authorizationState.AccessToken));
                return Redirect(tourl);
            }
