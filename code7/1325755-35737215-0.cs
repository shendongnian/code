                            movements
                            .Select(m => new[] { m.MovedFrom, m.MovedTo })
                            .SelectMany(i => i)
                            .Distinct()
                            .OrderBy(e => e)
                            .Select(e => new
                            {
                                categories = e,
                                leaving = movements.Count(x => x.MovedFrom == e),
                                arriving = movements.Count(x => x.MovedTo == e)
                            });
