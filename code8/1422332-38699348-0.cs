    HttpClient client = new HttpClient();
    var imageStream = File.OpenRead(@"C:\p1.jpg");
    var content = new StreamContent(imageStream);
    content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
    var response = await client.PostAsync("URL", content);
