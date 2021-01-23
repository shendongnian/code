    // fake data
    var data = @"1 | 4 | 12
                2 | 4 | 12
                3 | 12 | 4
                4 | 1 | 8
                5 | 3 | 12
                6 | 8 | 1"
    .Split('\n')
    .Select(x => x.Split(new[] { " | " }, StringSplitOptions.None));
    var spellsList = data.Select(x => new[]
    {
        int.Parse(x[1]), int.Parse(x[2])
    });
    // query
    var combos = spellsList
        .GroupBy(spells => string.Join(", ", spells.OrderBy(x => x)), (k, g) => new
        {
            SpellCombo = k,
            CastCount = g.Count(),
        })
        .OrderBy(x => x.CastCount)
        .ToList();
        
    foreach(var combo in combos)
    {
        Console.WriteLine($"Combo {combo.SpellCombo} is casted {combo.CastCount} times. ");
    }
