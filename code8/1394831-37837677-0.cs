    public PopulatePageCombosHelper populatePageHelper;
    public ActionResult SomeAction(int?id)
    {
       MyModel model = new MyModel();
       populatePageHelper.PopulatePageCombos(id);
       return View(model);
    }
