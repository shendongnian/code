    using(var client = new HttpClient()) {
                    client.BaseAddress = new Uri(SubscriptionUtility.GetConfiguration("BaseURI"));
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(SubscriptionUtility.GetConfiguration("ContentType")));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", SubscriptionUtility.GetConfiguration("BasicAuthentication"));
                    var values = new Dictionary<string, string>
                        {
                           { "request_key", "ABCD1234" },
                           { "request_code", "CODE" },
                           { "request_type", "ID_type" }
                        };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(SubscriptionUtility.GetConfiguration("SubscriptionAPI"), content);
                    var responseString = await response.Content.ReadAsStringAsync();
