    for (int i = 0; i < categories.count; i++)
    {
        ...
        if(...)
        {
            Category subcategory = new Category();
            ...
            categories.Add(subcategory);
            i--;
        }
     }
