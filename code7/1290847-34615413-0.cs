        public async Task<HttpResponseMessage> PostAsJsonAsync<T>(Uri uri, T item)
        {
            var itemAsJson = JsonConvert.SerializeObject(item);
            var content = new StringContent(itemAsJson);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await _client.PostAsync(uri, content);
        }
