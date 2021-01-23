    public virtual void PopulatePageCombos(int? id)
    {
        throw new NullReferenceException();
    }
    public ActionResult SomeAction(int? id)
    {
        MyModel model = new MyModel();
        this.PopulatePageCombos(id);
        return View(model);
    }
