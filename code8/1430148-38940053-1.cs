    public static List<Category> getCategoryList()
    {
        try
        {
            using (var db = new LinqToDBAwkoDataContext())
            {
                var list = from c in db.tblCategories
                           join s in db.tblSubCategories
                           select new Category
                           {
                               id = c.CatId,
                               catName = c.CatName,
                               subCat = s.SubCatName
                           };
                return list.ToList();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error has occured");
        }            
    }
