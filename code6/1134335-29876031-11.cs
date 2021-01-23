    Item_WithCategory.Result[] all;
    using (var session = DocumentStoreHolder.Store.OpenSession())
    {
        all = session.Query<Item_WithCategory.Result, Item_WithCategory>()
            .As<Item_WithCategory.Result>()         
            .ToArray();
    }
