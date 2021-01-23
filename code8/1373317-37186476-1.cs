    public ActionResult getuser(UserModel user)
    {
        var httpClient = HttpClientHelper.GetHttpClient();
        HttpResponseMessage response = httpClient.GetAsync(baseUrl + "api/Admin/GetStates").Result;
        if (response.IsSuccessStatusCode)
        {
            string stateInfo = response.Content.ReadAsStringAsync().Result;
        }
    }
    
