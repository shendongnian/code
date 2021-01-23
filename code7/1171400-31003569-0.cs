    var result = records
        .GroupBy(x => new { x.Prop1, x.Prop2 })
        .Select(g => new CustomType 
        {
            Prop1 = g.Key.Prop1,
            Prop2 = g.Key.Prop2,
            Prop3 = String.Join(", ", g.Select(x => x.Prop3))
        });
