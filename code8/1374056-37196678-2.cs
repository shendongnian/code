    var map = values.GroupBy(v => v.Section, v => v.Name)
        .ToDictionary(g => g.Key, g => g.Count());
    var result = values.Select(v => new
        {
          Section = v.Section,
          SecCode = v.SecCode,
          Name = v.Name,
          Count = map[v.Section]
        });
