    var result = items.Aggregate(new List<List<Item>> { new List<Item>() }, (list, value) =>
    {
        list.Last().Add(value);
        if (value.FinalValue == 0)
        {
            list.Add(new List<Item>());
        }
        return list;
    });
