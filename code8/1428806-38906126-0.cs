    public ActionResult Index()
    {
        var user = Session["loggedUser"] as User;
        user = db.Users.Find(user.id);
        if(!user.hasReadTerms)
        {
            return Redirect("/Terms");
        }else
        {
            //continue
        }
    }
