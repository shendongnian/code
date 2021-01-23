    [HttpPost]
    [Authorize] 
    public ActionResult DoSomeStuff (string id, string doSomething)  
    {
        var service = new Service(_db);
        var league = service.GetLeagueById(id);
        if (!HasAccessToLeague(User.Identity.Name, league)) 
        {
            // you are not suppose to modify the contents of this league
            // throw him a 404 or something
        }
        else
        {
            if (league != null) 
            {
                // validate doSomething
                league.Action = doSomething;
                _db.SaveChanges();
            }
        }
    
        return new EmptyResult(); 
    }
