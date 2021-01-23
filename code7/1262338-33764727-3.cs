    [MyCustomAttribute("The parameter for id is {id}")]
    public ActionResult Report(int id)
    {
        Guid userId = GetUserInfo();
    
        ... logic ...
    }
