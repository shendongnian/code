    var sportCategory = new Category { CategoryName = "Sport" };
    var musicCategory = new Category { CategoryName = "Music" };
    context.Categories.AddOrUpdate(p => p.CategoryName, 
       sportCategory, musicCategory);
    
    var footballSub = new Subcategory { SubcategoryName = "Football" };
    var basketballSub = new Subcategory { SubcategoryName = "Basketball" };
    var pianoSub = new Subcategory { SubcategoryName = "Piano" };
    var violinSub = new Subcategory { SubcategoryName = "Violin" };
    context.Subcategories.AddOrUpdate(p => p.SubcategoryName,
       footbalSub, basketballSub , pianoSub, violinSub);
    context.Services.AddOrUpdate(p => p.ServiceType,
        new Service
        {
            ServiceType = "Football player",
            Category = sportCategory,
            Subcategory = footballSub
        },
        new Service 
        {
            ServiceType = "Piano lessons",
            Category = musicCategory,
            Subcategory = pianoSub
        }
    );
