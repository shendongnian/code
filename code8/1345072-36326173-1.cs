    public IEnumerable<CategoryModel> GetAllCategories()
            {
                using (var conn = ConnectionSettings.GetSqlConnection())
                      {
                          const string sql = @" SELECT
                                c.CategoryName,     
                                c.CategoryId from Category c;
                                SELECT
                                i.ItemId,
                                i.ItemName,                                
                                i.CategoryId 
                            from item i";   
    
    
        var reader = conn.QueryMultiple(sql);
        IEnumerable<CategoryModel> categoriesList = reader.Read<CategoryModel>();
         IEnumerable<ItemModel> itemList = reader.Read<ItemModel>();
    
        foreach(Category c in categoriesList)
        {
           c.items = itemList.Where(i => i.CategoryId = c.CategoryId)
        }
    
        return categoriesList;
    
    
                              }
            }
