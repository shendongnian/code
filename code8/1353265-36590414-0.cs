        public ActionResult Create()
        {
          
            
            List<MyADUsers> TheAllADUsers = new List<MyADUsers>();
            var context = new PrincipalContext(ContextType.Domain, "MyDoman.org");
            var searcher = new PrincipalSearcher(new UserPrincipal(context));
            foreach (var result in searcher.FindAll())
            {
                
                TheAllADUsers.Add(new MyADUsers { ADUserName = result.SamAccountName, AD_IsMemberOf = result.UserPrincipalName, FullName = result.Name });
            }
            db.MyADUsersContext.AddRange(TheAllADUsers);
            db.SaveChanges();
            
            return View();
        }
