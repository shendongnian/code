    public ViewActionResult SomeAction(SomeModel model)
    {
         Session["remember"] = model.someProperty;
         return View();
    }
