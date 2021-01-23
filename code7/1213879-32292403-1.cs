    [ChildActionOnly]
    public AtionResult NewUser()
    {
      return PartialView(new UserDetailViewModel());
    }
