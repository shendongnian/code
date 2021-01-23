    public ActionResult Index()
    {
         var roles = db.User_Role.ToList();
         var sites = db.Sites.ToList(); // i don t know how you get this information in your exemple.
         //define here every property of the PageModel you want to use there
         var model = new PageModel();
         model.UserName = roles.UserName;
         model.SiteName = sites.Select(...).SiteName;
         return View(model);
    }
