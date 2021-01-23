    public void FillCbCategories()
    {
        SamsonEntities db = new SamsonEntities();
    
        cboCat.Items.Clear();
    
        var listCat = (from cats in db.Categories                           
           select new CategoryDisplay()
           {
              CategoryID = cats.CategoryID,
              CategoryName = cats.CategoryName
           }).ToList();
    
        for(var i=0;i<listCat.Count;i++)
        {
           cboCat.Items.Add(listCat[i]);
        }
    
        cboCat.ValueMember = "CategoryID";
        cboCat.DisplayMember = "CategoryName";
    } 
