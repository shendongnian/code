       public ActionResult Register()
        {
            CDraguseniDBEntities dbContext = new CDraguseniDBEntities();
            UserModel um = new UserModel();
            IEnumerable<SelectListItem> items = new SelectList(dbContext.Roles, "RoleID", "RoleName", um.RoleID);
            ViewBag.RoleList = items;
     /* 
            IEnumerable<SelectListItem> items = dbContext.Roles.Select(c => new    SelectListItem
            {
               
                Text=c.RoleName,
               
            });
            ViewBag.RoleID = items;*/
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel U)
        {
            if (ModelState.IsValid)
            {
                using (CDraguseniDBEntities dc = new CDraguseniDBEntities())
                {
                   
                    var count = dc.Users.Count(use => use.Username == U.Username);
                    //you should check duplicate registration here 
                   if(count==0)
                   {
                       Users user = new Users();
                     
                       user.RoleID = U.RoleID;
                       user.FirstName = U.FirstName;
                       user.LastName = U.LastName;
                       user.Email = U.Email;
                       user.Username = U.Username;
                       user.Password = U.Password;
                       dc.Users.Add(user);
                       dc.SaveChanges();
                       ModelState.Clear();
                       U = null;
                       ViewBag.Message = "Successfully Registration Done";
                      
                   }
                   else
                   {
                       ViewBag.Message = "User already exist";
                   }
                }
            }
            return View(U);
        }
