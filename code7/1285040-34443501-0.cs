    public async Task<ActionResult> Index()
    {
        HttpClient client = new HttpClient();
        var httpMessage = await client.GetAsync("http://www.google.com");
    
        var r = await httpMessage.Content.ReadAsStringAsync();
    
        return Content(r);
    }
