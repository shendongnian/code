    var logIn = new Models.LogIn()
    {
        Username = "username",
        Password = "password"
    };
    var logInJson = JsonConvert.SerializeObject(logIn);
    HttpClient httpClient = new HttpClient();
    var httpContent = new StringContent(logInJson);
    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
    await httpClient.PostAsync("http://localhost:56267/api/LogIns", httpContent);
