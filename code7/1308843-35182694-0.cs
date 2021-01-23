    public ActionResult Index(string username, string password)
        {
            if (username != "" && password != "")
            {
                //checking is user already exists
    
                //Here problem arise...
                userName = userName.ToUpperInvariant ();
                var query = db.Users.Where(i => i.Username.ToUpper ().Equals(username)).ToList();
                User res = null;
                if(query.Count == 1)
                {
                    res = query.First();
                }
                if (res != null)
                {
                    //My remaining code
                }
            }
            return View("Index");
        }
