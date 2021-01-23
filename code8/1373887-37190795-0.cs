    List<int> allIds = parent
        .SelectMany(p => new[] {p.Id} // or Enumerable.Repeat(p.Id, 1)
            .Concat(p.C1.Select(c => c.Id))
            .Concat(p.C2.Select(c => c.Id)))
        .ToList();
