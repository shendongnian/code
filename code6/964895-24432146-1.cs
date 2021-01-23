    public ActionResult Search(string[] Users)
    {
        var terms = Users.Split();
        var predicate = PredicateBuilder.False<User>90;
        foreach (var term in terms)
        {
             var temp = term; // avoid capture of loop variable
             predicate.Or(p => p.UserName.Contains(temp)
                                || p.About.Contains(temp)
                                || p.City.Contains(temp));
        }
    
        var v = db.UserProfiles.Where(predicate);
    
        return View("Find", v.ToList());
    }
