    public async Task<ActionResult> Index()
    {
        Task<string> task =  SomeMethodOne();
        SomeMethodTwo();
        string result = await task;
        return View();
    }
