    HttpClient httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri(url);
    httpClient.DefaultRequestHeaders.Authorization = 
        new AuthenticationHeaderValue(
            "Basic", 
            Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "yourusername", "yourpwd"))));
    
    
    HttpResponseMessage reponse = httpClient.GetAsync("api/enumproducts/GetAll").Result;
    if (reponse.IsSuccessStatusCode)
    {
    var enumProducts = reponse.Content.ReadAsAsync<List<EnumProduct>>().Result;
    }
