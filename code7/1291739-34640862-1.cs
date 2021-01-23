    using (var db = new MyContext())
    {
        var itemQuery = db.Items.IncludeUser();
    
        itemQuery = itemQuery.IncludePrimaryNode();
    
        var item = itemQuery.FirstOrDefault(i => i.Id == 1);
    }
