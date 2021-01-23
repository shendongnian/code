    var propValueByName = item
        .value
        .GetType()
        .GetProperties()
        .Select(p => new {
            p.Name
        ,   Val = p.GetValue(item.value, null)
        }).Where(p => p.Val != null)
        .ToDictionary(p => p.Name, p => p.Val.ToString());
