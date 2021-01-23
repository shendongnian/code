    public ActionResult SomeAction()
    {
        var vm = new SomeViewModel();
        RenderMode("~/views/shared/_MainLayout.cshtml");
        return PartialView(vm);
    }
