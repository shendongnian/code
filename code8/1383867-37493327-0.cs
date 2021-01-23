      var l = str.Split(new[] { '\n' },   
        StringSplitOptions.RemoveEmptyEntries)
        .Select(p => p.Trim())
        .Where(p =>!string.IsNullOrWhiteSpace(p))
        .SelectMany(w => w.Split(new[] { ' ' },  ringSplitOptions.RemoveEmptyEntries)
        .Select(p => p.Trim())
        .Where(p => !string.IsNullOrWhiteSpace(p))
        .Concat(new[] { "\n" });
