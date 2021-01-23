     [HttpPost]
        public ActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {
                using (dbPA_MVCEntities objCon = new dbPA_MVCEntities())
                {                    
                    List<PROC_LogIn_Info_Result> LoginUser = objCon.PROC_LogIn_Info(user.vUserid, user.vPassword).ToList<PROC_LogIn_Info_Result>();
                    if (LoginUser.Count > 0)
                    {
                        Session["UserID"] = LoginUser[0].vUserid;
                        Session["UserName"] = LoginUser[0].vUserName;
                        Session["UserRole"] = LoginUser[0].vRole;
                        Session["UserType"] = LoginUser[0].vUserType;
                        Session["UserEmailId"] = LoginUser[0].vUserEmail;
                    }
                    else
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");                       
                }
            }
            else
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return RedirectToAction("LoginIndex", "Login");
        }
