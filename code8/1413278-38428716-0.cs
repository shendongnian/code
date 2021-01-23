    List<CategoryEnt> CategoryEntList = new List<CategoryEnt>();       
    while (reader.Read())
    {
        CategoryEntList.Add(new CategoryEnt(){ 
        CategoryID = Convert.ToInt32(reader["CategoryID"]),
        CategoryName = reader["CategoryName"].ToString(),
        ImageURL = reader["ImageURL"].ToString(),
        });
    }
    var requiredValues = CategoryEntList.Select(x => new 
                                        { CategoryID = x.CategoryID, 
                                          CategoryName = x.CategoryName, 
                                          ImageURL = x.ImageURL 
                                        }).ToList();
