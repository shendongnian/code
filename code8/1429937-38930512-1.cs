    [ChildActionOnly]
    public ActionResult BackgroundImage() 
    {
        var model = new MyViewModel
        {
            BackgroundImageUrl = ...
        };
        return PartialView(model);
    }
