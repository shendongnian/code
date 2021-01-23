    [HttpPost]
    public async Task<ActionResult> Create(User source)
    {
        if (Request.Cookies["AdminCookie"] == null)
            return RedirectToRoute("Home");
    
        if (ModelState.IsValid)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49474/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    var response = await client.PostAsJsonAsync("api/user", source); //debug here to ensure you are getting a response
    
                    if (response.IsSuccessStatusCode)
                    {
                        return Responder("Success", true);
                    }
                }
                return Responder();
            }
            catch(Exception ex)
            {
                ReportError(ex, "CREATE");
                return Responder();
            }
        }
    }
    private object Responder(string message = "Did not succeed", bool succeeded = false)
    {
        return new
             {
                 Message = message,
                 IsOK = succeeded
             };
    }
