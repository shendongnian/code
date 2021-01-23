    [ChildActionOnly]
    public ActionResult AdminMenu(AdminMenuViewModel model)
    {
        return Partial(model);
    }
