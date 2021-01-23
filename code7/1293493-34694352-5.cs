    public ActionResult Index(int? id)
    {
        var viewModel = new Klient_has_SklepIndexData();
        viewModel.Klients = db.Klients
                            .OrderBy(i => i.Nazwisko).ToList();        
        UserManager UM = new UserManager();
        int idZalogowanego = UM.GetUserID(User.Identity.Name);
        ViewBag.idzal = idZalogowanego;
    
        viewModel.Klient_has_Skleps.Add(viewModel.Klients.Where(i => i.SYSUserID == idZalogowanego).First().Klient_has_Sklep);
    
        return View(viewModel);
    }
