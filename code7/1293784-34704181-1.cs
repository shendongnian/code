        public void Test() {
            using (HttpClient client = new HttpClient()) {
            client.BaseAddress = new Uri("http://testservice.cloudapp.net");
            var response = client.PostAsync("api/test?value=1234", new StringContent(string.Empty)).Result;
            var statusCode = response.StatusCode;
            var errorText = response.ReasonPhrase;
            // response.EnsureSuccessStatusCode(); will throw an exception if status code does not indicate success
            var responseContentAsString = response.Content.ReadAsStringAsync().Result;
            var responseContentAsBYtes = response.Content.ReadAsByteArrayAsync().Result;
        }
    }
