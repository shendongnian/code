    [Authorize(Roles = "RegisteredUsers")]
        public ActionResult Index(string searchString)
        {     
             var regUsers = null;
      
            if (!String.IsNullOrEmpty(searchString))
            {
                regUsers = regUsers.Where(s => s.User.LastName.Contains(searchString));
            }
    
            return View(regUsers.ToList());
        }
