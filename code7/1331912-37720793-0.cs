    public IViewComponentResult Invoke()
    {
      if (User.IsInRole(UserRoles.CLIENT))
         return View("_ClientMenu");
    
      return Content(string.Empty);
    }
