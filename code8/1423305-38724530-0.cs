    HttpClient OpenClient = new HttpClient();
    var response = await OpenClient.GetAsync("imageUrl.jpg");
    if (response.StatusCode == System.Net.HttpStatusCode.OK)
    {
        Stream stream = await response.Content.ReadAsStreamAsync();
    }
