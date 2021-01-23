    class Category
    {
      public string Name {get;set;}
      public string Id {get;set;}
    }
    List<Category> categories = new List<Category>();
    while (objDR.Read())
    {
        categories.Add(new Category { 
           Name = objDR["ct_name"],
           Id =  objDR["ct_id"],
        };
    }
