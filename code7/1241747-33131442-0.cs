        public async Task GetIndexAsync()
        {
            HttpResponseMessage httpResponse = null;
            try
            {
                _http.BaseAddress = new Uri("http://localhost:43818/");
                httpResponse = await _http.GetAsync("api/values");
            }
            catch (Exception e)
            {
                var meessage = e.Message;
                var stack = e.StackTrace;
            }
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string json = await httpResponse.Content.ReadAsStringAsync();
            }
        }
