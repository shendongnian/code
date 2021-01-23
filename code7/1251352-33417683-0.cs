      [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register registerdata, string RoleName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registerdata.Username, registerdata.Password);
                    System.Web.Security.Roles.AddUserToRole(registerdata.Username, RoleName);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException exception)
                {
                    ModelState.AddModelError("", "Warning: Username exist...");
                    ViewData["roleName"] = GetRoles();
                    return View(registerdata);
                }
            }
            ModelState.AddModelError("", "Warning: Username exist....");
            ViewData["roleName"] = GetRoles();
            return View(registerdata);
        }
     private IEnumerable<SelectListItem> GetRoles()
     {
            //Roles for DropDown Box
            IEnumerable<SelectListItem> RolesList = new  System.Web.Mvc.SelectList(System.Web.Security.Roles.GetAllRoles(), "roleName");
     }
