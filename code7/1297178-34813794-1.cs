        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            List<Models.Server> serverList = new List<Models.Server>()
            {
                new Server {server = "abc"}, 
                new Server {server = "xyz"}, 
                new Server {server = "def"}
            };
            return View(serverList);
        }
