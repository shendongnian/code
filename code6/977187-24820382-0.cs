    public ActionResult Details(Item item)
    {
        var db = new appContext();
        ViewBag.Item = item.ItemTitle;
        ViewBag.ItemLink = "http://.../Items/Details/" + item.ItemId;
        ViewBag.Categories = item.Categories.Select(c => new { c.CategoryName, c.CategoryId });
    
        return View();
    }
