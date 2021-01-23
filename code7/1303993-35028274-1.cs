    public ActionResult Index()
    {
        return View(db.Users.Select(u=>new VMUsers{ Id=u.Id,
                                                    FullName=u.FullName,
                                                    LastName=u.LastName,
                                                    Address2=u.Detail.Address1,
                                                    Address1=u.Detail.Address2}));
    }
