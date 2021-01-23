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
                        return new
                            {
                                Message = "Success",
                                IsOK = bool.TrueString
                            };
                    }
                }
                return new
                            {
                                Message = "Did not succeed",
                                IsOK = false
                            };
            }
            catch(Exception ex)
            {
                ReportError(ex, "CREATE");
                return new
                            {
                                Message = "Did not succeed",
                                IsOK = false
                            };
            }
        }
    }
