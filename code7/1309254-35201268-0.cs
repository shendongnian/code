    public ActionResult Index()
    {
        test(User);
        return View();
    }
    public void test(IPrincipal user)
    {
        foreach(var item in db.SetValue.ToList())
        {
            var setvalcon = new SetValuesController();
            setvalcon.Edit(item, user);
        }     
    }
  
