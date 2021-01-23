    public async Task<ActionResult> Delay()
    {
        var tasks= new List<Task>();
        var client1 = new HttpClient();
        tasks.Add(client1.GetAsync("http://httpbin.org/delay/3"));
        var client2 = new HttpClient();
        tasks.Add(client2.GetAsync("http://httpbin.org/delay/3"));
        await Task.WhenAll(tasks);
        return View("~/Views/Dashboard/Test.cshtml");
