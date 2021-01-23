    public async Task TestAsync() {
            using (HttpClient client = new HttpClient()) {
    
                client.BaseAddress = new Uri("http://testservice.cloudapp.net");
                var response = await client.PostAsync("api/test?value=1234", new StringContent(string.Empty));
                var statusCode = response.StatusCode;
                var errorText = response.ReasonPhrase;
    
                // response.EnsureSuccessStatusCode(); will throw an exception if status code does not indicate success
    
                var responseContentAsString = await response.Content.ReadAsStringAsync();
                var responseContentAsBYtes = await response.Content.ReadAsByteArrayAsync();
            }
    
        }
