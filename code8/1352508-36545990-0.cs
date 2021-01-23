    using (var context = new SomeContext()) // static connection string
    {
        var query = context.SomeTable.AsQueryable();
        if (SelectedFilter == Today)
            query = query.Where(o => o.Id >= DateTime.Today);
        ...
        // constructing ViewModel items (WPF, MVVM)
        foreach (var item in query)
            items.Add(new Item()
            {
                Id = item.Id,
                ...
            }
    }
