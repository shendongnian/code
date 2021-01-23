        public ActionResult Index(int? id)
        {
            var viewModel = new Klient_has_SklepIndexData();
            viewModel.Klients = db.Klients
                                .OrderBy(i => i.Nazwisko).ToList();        
            UserManager UM = new UserManager();
            int idZalogowanego = UM.GetUserID(User.Identity.Name);
            ViewBag.idzal = idZalogowanego;
            
            var skelp = viewModel.Klients.FirstOrDefault(i => i.SYSUserID == idZalogowanego);
            if(skelp != null){
                if(skelp.Klient_has_Sklep != null){
                    viewModel.Klient_has_Skleps = skelp.Klient_has_Sklep.ToList();
                }
            }
        
            return View(viewModel);
        }
