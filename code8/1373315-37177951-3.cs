    public ActionResult getuser(UserModel user, HttpClient httpClient)
    {
      HttpResponseMessage response = httpClient.GetAsync("api/Admin/GetStates").Result;
    
      if(response.IsSuccessStatusCode)
      {
        string stateInfo = response.Content.ReadAsStringAsync().Result;
      }
    
      // the rest of your code for getuser..
    
      return View();
    }
