    public class JsonSend<I, O>
        {
    
            public async Task<O> DoPostRequest(string url, I input)
            {
                var client = new HttpClient();
                CultureInfo ci = new CultureInfo(Windows.System.UserProfile.GlobalizationPreferences.Languages[0]);
    
                client.DefaultRequestHeaders.Add("Accept-Language", ci.TwoLetterISOLanguageName);
                var uri = new Uri(string.Format(
                    url,
                    "action",
                    "post",
                    DateTime.Now.Ticks
                    ));
    
                string serialized = JsonConvert.SerializeObject(input);
    
                StringContent stringContent = new StringContent(
                    serialized,
                    Encoding.UTF8,
                    "application/json");
    
                var response = client.PostAsync(uri, stringContent);
    
                HttpResponseMessage x = await response;
                if (x.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    //throw new ConnectionOutException("While puting: " + url + " we got the following status code: " + x.StatusCode);
                }
                HttpContent requestContent = x.Content;
                string jsonContent = requestContent.ReadAsStringAsync().Result;
    
                return JsonConvert.DeserializeObject<O>(jsonContent);
            }
    
            public async Task<O> DoPutRequest(string url, I input)
            {
                var client = new HttpClient();
                CultureInfo ci = new CultureInfo(Windows.System.UserProfile.GlobalizationPreferences.Languages[0]);
                client.DefaultRequestHeaders.Add("Accept-Language", ci.TwoLetterISOLanguageName);
                var uri = new Uri(string.Format(
                    url,
                    "action",
                    "put",
                    DateTime.Now.Ticks
                    ));
    
                var response = client.PutAsync(uri,
                new StringContent(
                    JsonConvert.SerializeObject(input),
                    Encoding.UTF8,
                    "application/json"));
    
                HttpResponseMessage x = await response;
                if (x.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    //throw new ConnectionOutException("While puting: " + url + " we got the following status code: " + x.StatusCode);
                }
                HttpContent requestContent = x.Content;
                string jsonContent = requestContent.ReadAsStringAsync().Result;
    
                return JsonConvert.DeserializeObject<O>(jsonContent);
            }
        }
