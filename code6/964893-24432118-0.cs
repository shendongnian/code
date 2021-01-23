    public ActionResult Search(string[] Users)
    {
        var v = from p in db.UserProfiles
                where (Users.Any(x=>p.UserName.Contains(x)) ||
                      (Users.Any(x=>p.About.Contains(x)) ||
                      (Users.Any(x=>p.City.Contains(x))
                select p;
        return View("Find", v.ToList());
    }
