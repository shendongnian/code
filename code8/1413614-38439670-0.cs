    // Replace with your real model from MVC
    var model = new Model { SelectedCategoriesIds = new List<int>() };
    model.SelectedCategoriesIds.Add(1);
    model.SelectedCategoriesIds.Add(2);
    model.SelectedCategoriesIds.Add(3);
    
    var newsToUpdate = new News {  Categories = new List<Category>() }; // Replace with your call to database
                
    // Use an Entity Framework context to update our db model
    using (var dbContext = new MyDbContext())
    {
        // First clear existing categories
        newsToUpdate.Categories.Clear();
    
        // Now add selected categories
        foreach (var selectedCategory in model.SelectedCategoriesIds)
        {
            var dbCat = dbContext.Categories.Single(c => c.Id == selectedCategory);
            newsToUpdate.Categories.Add(dbCat);
        };
    
        // Save changes
        dbContext.SaveChanges();
    }
