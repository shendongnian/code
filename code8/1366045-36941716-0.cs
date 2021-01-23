    public async Task<ActionResult> SomeAction()
    {
        IUser result = await azureDirectoryClient.Users.GetByObjectId(someId).ExecuteAsync();
        return View(result);
    }
