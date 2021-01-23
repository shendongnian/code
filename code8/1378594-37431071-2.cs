    [ChildActionOnly]
    public ActionResult Menu(string userName)
    {
        UserBaseVM model = new UserBaseVM(){ UserName = userName });
        ....
        return PartialView(model);
    }
