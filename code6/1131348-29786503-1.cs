    public ActionResult GetCategories(int? v)
    {
        var items = Db.Categories
            .Select(o => new SelectableItem(o.Id, o.Name, v == o.Id));// value,     text, selected
        return Json(items);
    }
    public ActionResult GetMeals(int? v, int? parent)
    {
        var items = Db.Meals.Where(o => o.Category.Id == parent)
            .Select(o => new SelectableItem(o.Id, o.Name, v == o.Id));// key,     text, selected
        return Json(items);
    } 
