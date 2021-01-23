    public class JsonGet<O>
    {
        public async Task<O> DoGetRequest(string url)
        {
            var client = new HttpClient();
            CultureInfo ci = new CultureInfo(Windows.System.UserProfile.GlobalizationPreferences.Languages[0]);
            client.DefaultRequestHeaders.Add("Accept-Language", ci.TwoLetterISOLanguageName);
            var uri = new Uri(string.Format(
                url,
                "action",
                "get",
                DateTime.Now.Ticks
                ));
            var response = client.GetAsync(uri);
            HttpResponseMessage x = await response;
            if (x.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //throw new ConnectionOutException("While posting: " + url + " we got the following status code: " + x.StatusCode);
            }
            HttpContent requestContent = x.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            JsonConvert.DeserializeObject<O>(jsonContent);
            return JsonConvert.DeserializeObject<O>(jsonContent);
        }
    }
