    public Models.CategoryModel GetAllCategories()
    {
        var TheModel = new Models.CategoryModel();
        TheModel.Section1Categories = GetCategoryRange(1, 7);
        TheModel.Section2Categories = GetCategoryRange(7, 9);
    } // end Get All Categories
    
    private IEnumerable<Models.CategoryModel.Category> GetCategoryRange(Int32 LowId, Int32 HighId)
    {
        // This is using LINQ.  You could accomplish this with other technologies as well
        var cats = (from c in m_db.Category
                    where c.Id >= LowId &&
                    c.Id <= HighVal
                    select new Models.CategoryModel.Category()
                    {
                        Id = c.Id,
                        Name = c.Name
                    });
        return cats;
    } // end GetCategoryRange
