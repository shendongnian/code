    [HttpGet]
      public ActionResult Index()
      {
    
            return View();
      }  
    
      [HttpPost]
      public ActionResult Index(string SearchString)
      {
            var Client = from c in db.Clients
    
                         select c;
    
            if (!String.IsNullOrEmpty(SearchString))
            {
                Client = Client.Where(s => s.Name.Contains(SearchString));
            }
    
            return View(Client);
       }
