    [HttpGet]
    public HttpResponseMessage getData()
    {
      var firstObj = dbContext.Customer();
      var secondObj= dbContext.Department();
      var thirdObj= dbContext.Email();
      return new { firstObj,secondObj,thirdObj };
    }
    
        /* this is my client side call */
    using (var client = new HttpClient())
    {
           client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CommonHelper.CurrentToken);
           client.BaseAddress = new Uri(CommonHelper.baseAddress);
           HttpResponseMessage response = await client.GetAsync("/OPUS/Accounts/getData");
           response.EnsureSuccessStatusCode(); 
    }
