    LoadButton.IsEnabled = false;
    
    var users = await Task.Run(() => 
    {
        using(TestContext ctx = new TestContext())
        {
            return ctx.Users.ToList();
        }
    });
    
    LoadButton.IsEnabled = true;
