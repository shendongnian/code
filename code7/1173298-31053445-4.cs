    public virtual ActionResult Index()     
    {
        [...]
        string name = "name";
        ModelXXXX model = new ModelXXXX(GetxxxoList(name), List());
        return View("..Views/Index.cshtml", model)
    }
