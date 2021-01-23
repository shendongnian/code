        using Windows.Web.Http;
        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            try
            {
                var o = new
                {
                    operation = "NewEvent",
                    location_id = locationID,
                    eventName = eventName
                };
                HttpStringContent content = new HttpStringContent(JsonConvert.SerializeObject(o), Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(urlPostData), content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // TODO: Do something with the responseBody
            }
            catch (Exception)
            {
                // TODO: Deal with exception - could be a server not found, 401, 404, etc.
            }
        }
