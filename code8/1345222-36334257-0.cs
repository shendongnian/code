      string requestUrl = string.Format("{0}/users/{1}?api-version={2}", baseUrl, userGuid, apiVersion);
                string responseBody = null;
                try
                {
                    using (HttpClient httpClient = new HttpClient())
                    { 
     var request = new HttpRequestMessage(HttpMethod.Put, requestUrl);
                            request.Headers.Authorization =
                                new AuthenticationHeaderValue("SharedAccessSignature", sharedAccessSignature);
                            request.Content = new StringContent("{\"firstName\": \"MyFirstName\",\"lastName\": \"MyLastName\",\"email\": \"example@mail\",\"password\": \"Password;\",\"state\": \"active\"}", Encoding.UTF8,"application/json");
                            HttpResponseMessage response = await httpClient.SendAsync(request);`enter code here`
                            response.EnsureSuccessStatusCode();
                            responseBody = await response.Content.ReadAsStringAsync();
    }
                }
