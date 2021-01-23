    var sportCategory = new Category { CategoryID = 1000, CategoryName = "Sport" };
    var musicCategory = new Category { CategoryID = 1001, CategoryName = "Music" };
    context.Categories.AddOrUpdate(p => p.CategoryName, 
       sportCategory, musicCategory);
    
    var footballSub = new Subcategory { SubcategoryID = 1000, SubcategoryName = "Football" };
    var basketballSub = new Subcategory { SubcategoryID = 1001, SubcategoryName = "Basketball" };
    var pianoSub = new Subcategory { SubcategoryID = 1002, SubcategoryName = "Piano" };
    var violinSub = new Subcategory { SubcategoryID = 1003, SubcategoryName = "Violin" };
    context.Subcategories.AddOrUpdate(p => p.SubcategoryName,
       footbalSub, basketballSub , pianoSub, violinSub);
    context.Services.AddOrUpdate(p => p.ServiceType,
        new Service
        {
            ServiceType = "Football player",
            CategoryID = sportCategory.CategoryID,
            SubcategoryID = footballSub.SubcategoryID
        },
        new Service 
        {
            ServiceType = "Piano lessons",
            CategoryID = musicCategory.CategoryID,
            SubcategoryID = pianoSub.SubcategoryID
        }
    );
