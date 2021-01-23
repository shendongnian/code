        private static T MakeRequest<T>(string httpMethod, string route, Dictionary<string, string> postParams = null, string contentJson = null)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), $"{_apiBaseUri}/{route}");
                if (!String.IsNullOrEmpty(contentJson))
                    requestMessage.Content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                if (postParams != null)
                    requestMessage.Content = new FormUrlEncodedContent(postParams);
                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                try
                {
                    // Attempt to deserialise the reponse to the desired type, otherwise throw an expetion with the response from the api.
                    if (apiResponse != "")
                        return JsonConvert.DeserializeObject<T>(apiResponse);
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error ocurred while calling the API. It responded with the following message: {response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }
