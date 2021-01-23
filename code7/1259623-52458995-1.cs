    var client = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Post, "http://<Host>/<Path>");
    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
    var httpResponseMessage = client.SendAsync(request).Result;
    var responseString = httpResponseMessage.Content.ReadAsStringAsync().Result;
