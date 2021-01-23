    var groups = xelement.Elements()
        .ChunkBy(x => x.Name.LocalName)
        .Where(g => g.Count() > 1)
        .OrderByDescending(g => g.Count())
        .Select(g => new{
                Tag = g.Key,
                Value = string.Join(" ", g.Select(x => x.Value)),
                Count = g.Count()
        });
