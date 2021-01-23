        public ActionResult Index() {
                var dictionary = new Dictionary<string, string>();
                var allGroup = GetAllGroupNames(); //Query to get all data from table
    
                foreach(var ag in allGroup)
                {
                    dictionary.Add(ag.GroupId.ToString(), ag.Name);
    
                }
                ViewBag.selectGroupList = dictionary; // Add dictionary to ViewBag
    
                return View();
          }
