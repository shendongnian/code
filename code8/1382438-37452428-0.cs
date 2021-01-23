    public async Task<ActionResult> GetSubCategoryList(string subCategory)
    {
        var model = db.ProductsList.Where(x => x.Subcategory.Name == subCategory).ToList(); 
        return PartialView(@"~/Views/Product/_ChemicalPartialView.cshtml", model);
    } 
