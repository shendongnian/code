    public async Task APIcall() {
        try {
                    
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://xxxx");
            requestMessage.Headers.Add("Accept", "application/json");
            requestMessage.Headers.Add("ContentType", "application/json");
            requestMessage.Headers.Add("RequestMessageGUID", "xxxxxx");
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
            if (response.Content.Headers.ContentLength.GetValueOrDefault() > 0) {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            } else {
                Console.WriteLine(response.StatusCode);
            }
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }
