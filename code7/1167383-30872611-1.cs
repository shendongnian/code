    foreach (var item in llistaobjectes)
    {
        objectes.AddRange(db.Items.Where(x => x.Id == item.items_id).Select(x => new
            {
                Id = x.Id,
                SKU = x.SKU, //No idea what your table looks like
                AnotherProperty = x.AnotherProperty, //again, no idea...
            }).ToList());
    }
