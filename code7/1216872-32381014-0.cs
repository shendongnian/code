    [HttpPost]
    public ActionResult Edit(MyItem model, bool checkOnly) 
    {
       return checkOnly ? Check(model) : Edit(model);
    }
    private ActionResult Edit(MyItem model)  {...}
    private ActionResult Check(MyItem model)  {...}
 
