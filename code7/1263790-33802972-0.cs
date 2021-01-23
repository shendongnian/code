    HttpClient client = new HttpClient();
    // A POST request needs HttpContent along with the webservice URI
    string body = "YOUR REQUEST BODY HERE"; // username/password in JSON format
    var content = new StringContent(body);
    client.PostAsync("YOUR_SERVICE_URL", content);
