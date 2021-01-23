    public ActionResult MyPage()
    {
        BLL.CategoryMethods cm = new BLL.CategoryMethods();
        Models.CategoryModel TheModel = cm.GetAllCategories();
        return View(TheModel);
    } // end MyPage
