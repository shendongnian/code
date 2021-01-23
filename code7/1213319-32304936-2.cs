    var dataContext = values[0];
    var someString = values[1] as string;
    var parameters = new Dictionary<string, object>();
    for (var i = 2; i < values.Length; i++)
    {
        var pair = values[i] as StringObjectPair;
        if (!string.IsNullOrEmpty(pair?.Key) && !parameters.ContainsKey(pair.Key))
        {
            var props = (pair.Value as string)?.Split('.') ?? Enumerable.Empty<string>();
            var value = props.Aggregate(dataContext, (current, prop) => current?.GetType().GetProperty(prop)?.GetValue(current, null));
            parameters.Add(pair.Key, value);
        }
    }
