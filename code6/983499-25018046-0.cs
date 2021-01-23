    .Filterable(f => f.Extra(false).Operators(o =>
    {
        o.ForDate(t =>
        {
            t.Clear();
            t.IsEqualTo("Equal To");
            t.IsGreaterThan("Greater Than");
            t.IsGreaterThanOrEqualTo("Greater Than Or Equal");
            t.IsLessThan("Less Than");
            t.IsLessThan("Less Than Or Equal");
        });
    }))
