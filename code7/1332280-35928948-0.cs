    var distinct =
        conflicts
            .GroupBy(
                x =>
                    {
                        var ordered = new[] { x.Item1, x.Item2 }.OrderBy(i => i);
                        return
                            new
                            {
                                Item1 = ordered.First(),
                                Item2 = ordered.Last(),
                            };
                    })
            .Distinct()
            .Select(g => g.First())
            .Dump();
