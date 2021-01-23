    [HttpPost]
    public ActionResult Initialize_Brochure(IEnumerable<ProductsPropertiesVM> model)
    {
        IEnumerable<int> selectedIDs = model.Where(x => x.IsChecked).Select(x => x.Property_ID);
        string ids = string.Join(",", selectedIDs);
        return RedirectToAction("Create_Brochure", new { id = ids });
    }
