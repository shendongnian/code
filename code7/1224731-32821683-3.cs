    public ViewResult Category(int id)
    {
        ViewBag.IsAjaxRequest = Request.IsAjaxRequest();
        var node = CategoriesHandler.Instance.First(x => x.CategoryId == id);
        var childCategories = CategoriesHandler.Instance.Where(x => x.ParentId == node.Id).ToList();
        ViewBag.Message = node.Name;
        return View(childCategories);
    }
