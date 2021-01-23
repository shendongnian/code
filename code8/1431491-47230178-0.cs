                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("X-Tenant", xTenant);
                var stringContent = String.Concat("grant_type=password&username=", HttpUtility.UrlEncode(username),
                    "&password=", HttpUtility.UrlEncode(password));
                var httpContent = new StringContent(stringContent, Encoding.UTF8, "application/x-www-form-urlencoded");
                var postTask = httpClient.PostAsync(apiLoginUrl, httpContent);
                postTask.Wait();
                var postResult = postTask.Result;
                var content = postResult.Content.ReadAsStringAsync().Result;
                dynamic jsonRes = JsonConvert.DeserializeObject(content);
                string access_token = jsonRes.access_token;
