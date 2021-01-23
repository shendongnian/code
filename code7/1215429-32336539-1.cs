    public BooksMap()
    {
        Id(x => x.Id);
        ...
        // this should be readonly
        // Map(x => x.CategoryId);
        Map(x => x.CategoryId)
           .Not.Update()
           .Not.Insert();
        //reference to categories
        References(x => x.Categories)...
