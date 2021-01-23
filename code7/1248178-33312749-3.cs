    private void AnyMethod()
    {
        // To get an instance of your RssChannel class with all the data:
        RssChannel rssChannel = XML.DeserializeData();
        // Do anything with the data. Example below:
        iTunes newITunes = new iTunes();
        List<Category> categoryList = new List<Category>();
        Category newCategory1 = new Category(); // Create new categories.
        newCategory1.category = "Allegro";
        categoryList.Add(newCategory1);
        Category newCategory2 = new Category();
        newCategory2.category = "Prestissimo";
        categoryList.Add(newCategory2);
        newITunes.Categories = categoryList; // Add the categories to list.
        rssChannel.iTunesList.Add(newITunes); // Add that list to iTunes list.
        // Now, to save the data, pass a reference to the instance we just worked on:
        XML.SaveData(ref rssChannel);
    }
