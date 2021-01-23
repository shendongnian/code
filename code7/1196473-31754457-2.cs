    using(MyDataContext db = new MyDataContext())
    {
        var itemNames = Items.Select(i=>i.name).ToList();
        var itemNamesInDb = db.Items.Where(i=>itemNames.Contains(i.Name)).Select(i=>i.Name).ToList();
        var itemNamesNotInDb = new HashSet<string>(itemNames.Except(itemNamesInDb));
        var itemsNotInDb = Items.Where(i=>itemNamesNotInDb.Contains(i.name)).ToList();
    
        db.Items.InsertAllOnSubmit(itemsNotInDb);
        db.SubmitChanges();
    }
