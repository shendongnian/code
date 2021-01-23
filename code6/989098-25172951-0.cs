    public Task<ActionResult> Index()
    {
      User spUser = null;
      var spContext = SharePointContextProvider.Current.GetSharePointContext(HttpContext);
      var model = new LoginViewModel();
      M_Users new_user = new M_Users()
      {
        Password = "123",
        FirstName = spUser.Title,
        Email = spUser.LoginName.Split('|')[2].ToString(),
        AdminCode = 1,
        IsDisabled = false,
        CountryId = 48,
        CityId = 149,
        DepartmentId = 3, 
        CreationDate = DateTime.Now,
        CreatorUserId = 1
      };
      var returnedUser = await AddUserAsync(new_user);
      ViewBag.UserId = returnedUser.UserID;
      return View(model);
    }
