    var input = new[]
        {
            new { Key1 = 87, Key2 = 99 },
            new { Key1 = 42, Key2 = -8 }
        };
    var json = JSON.Serialize(Transform(input));
    object Transform(object[] input)
    {
        var props = input.GetProperties().ToArray();
        var keys = new[] { "$" }.Concat(props.Select(p => p.Name));
        var stripped = input.Select(o => props.Select(p => p.GetValue(o)).ToArray();
        return keys.Concat(stripped);
    }
