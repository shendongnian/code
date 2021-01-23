    [HttpGet]
        public ActionResult Index(string message)
        {
            var Result = from Client in db.Clients
                           where Clients.ClientName == message
                           select Clients.ClientName;
    
            ViewBag.Message = Result.ToList();
    
            getCurrentUser();
            return View();
        }
