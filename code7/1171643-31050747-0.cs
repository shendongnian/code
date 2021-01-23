    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(new { ticket = model }));
    if (httpContent.Headers.Any(r => r.Key == "Content-Type"))
        httpContent.Headers.Remove("Content-Type");
    httpContent.Headers.Add("Content-Type", "application/json");
    var httpRequest = new HttpRequestMessage()
    {
        RequestUri = new Uri(WebConfigAppSettings.ZendeskTicket),
        Method = HttpMethod.Post,
        Content = httpContent
    };
    httpRequest.Headers.Add("Authorization", String.Format("Basic {0}", Convert.ToBase64String(Encoding.UTF8.GetBytes(@"{username}:{password}"))));
    httpResult = httpClient.SendAsync(httpRequest);
