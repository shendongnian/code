    List<string> items = { "1", "6", "3", "Hi", "5", "Hello", "Hi" };
    var result = items.Select(x => new {
        IsInt = Int32.TryParse(x),
        TextValue = x
    });
    var integerCount = result.Where(x => x.IsInt).Count();
    var countPerText = result.Where(x => !x.IsInt)
        .GroupeBy(x => x.TextValue)
        .Select(group => new {
            Text = group.Key,
            Count = group.Count()
        });
