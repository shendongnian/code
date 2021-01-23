    public void AddCategory(int appId, string categoryName)
    {
        using(var context = new DbContext())
        {
            var category = context.CategoryModels.FirstOrDefault(x => x.Name == categoryName);
            if(category == null)
            {
                // Only create new CategoryModel if it doesn't exist.
                category = new CategoryModel
                {
                    Name = categoryName
                };
            }
            var appModel = new AppModel
            {
                id = appId
            };
            // Attach to save on db-trip
            context.AppModels.Attach(appModel);
    
            //TODO: Possibly check if this particular appModel already has this category?
            appModel.CategoryModels.Add(category);
            context.SaveChanges();
        }
    }
       
