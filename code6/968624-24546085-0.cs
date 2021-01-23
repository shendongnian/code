    public async Task<ActionResult> SomeAction()
    {
        var someData = await wcfServiceProxy.GetDataAsync()
        //some work with the data here
        return View(someData);
    }
