    public ActionResult Activités()
    {
        var s=new PageService();
        var model = new ModelDeBase { Slider =s.GetActualites()};
        return View(model);
    }
