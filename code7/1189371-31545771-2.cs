    [HttpPost]
    public ActionResult EditUserAccount_Save(UserAccountViewModel editUserAccountViewModel)
    {
    	if (ModelState.IsValid)
    	{
    		using (MyContext context = new MyContext())
    		{
                int userId = WebSecurity.GetUserId(editUserAccountViewModel.UserName);
    			db_user user = context.DbUsers.Where(u => u.Id == userId).Single();
    			editUserAccountViewModel.UserName = UserSession.GetValue(StateNameEnum.UserName, StateNameEnum.UserName.ToString()) as string;
    
    			user.Title = editUserAccountViewModel.Title;
    			user.FirstName = editUserAccountViewModel.FirstName;
    			user.LastName = editUserAccountViewModel.LastName;
    			user.PhoneNumber = editUserAccountViewModel.PhoneNumber;
    			user.AltPhoneNumber = editUserAccountViewModel.AltPhoneNumber;
    			user.EmailAddress = editUserAccountViewModel.EmailAddress;
    			user.LanguageId = context.languages.Where(t => t.Code == editUserAccountViewModel.Language).Select(t => t.Id).SingleOrDefault();
    			user.CreatedDate = DateTime.Now;
    
    			context.SaveChanges();
    
    			JsonResult res = Json(new { Success = true, data = "", Message = "" });
    			return res;
    		}
    	}
    	else
    	{
    		JsonResult res2 = Json(new { Success = false, data = "", Message = "" });
    		return res2;
    	}
    }
