    var query = results
        .Select(d => new { d.Name, Results = d.Rounds.Split('-').Select(int.Parse).ToList() })
        .GroupBy(
            d => d.Name, (key, values) => new {
                Name = key,
                Rounds = values.SelectMany(v => v.Rounds)
                               .Distinct()
                               .OrderBy(x => x)
                               .ToList()
           });
