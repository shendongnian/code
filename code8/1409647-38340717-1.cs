    public async Task<string> CreateSubcategory(SubcategoryViewModel model)
    {
       string fileName = null;
       if (model.PdfFile != null && model.PdfFile .ContentLength > 0)
       {
           fileName = Guid.NewGuid().ToString().Substring(0, 13) + "_" + model.PdfFile.FileName;
           string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/pdf"), fileName);
           model.PdfFile.SaveAs(path);
        }
        var subcategory = new Subcategory
        {
            Pdf = fileName ,
        };
        db.SubcategoriesList.Add(subcategory);
        await db.SaveChangesAsync();
