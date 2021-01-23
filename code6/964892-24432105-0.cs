    public ActionResult Search(string Users)
    {
        string[] terms = Users.Split();
        var v = from p in db.UserProfiles
                where (terms.Any(r=> p.UserName.Contains(r))) ||
                      (terms.Any(r => p.About.Contains(r))) ||
                      (terms.Any(r => p.City.Contains(r)))
                select p;
        return View("Find", v.ToList());
    }
