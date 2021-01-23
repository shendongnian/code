    public Controller UserController : Controller
    {
      UserDB _Repository = new UserDB(); // later you will use DI
      public ActionResult Index()
      {
        List<User> model = _Repository.Fetch();
        return View(model);
      }
      public ActionResult Edit(int ID)
      {
        User model = _Repository.Get(ID);
        if (model == null)
        {
          return new HttpNotFoundResult();
        }
        return View(model);
      }
    }
