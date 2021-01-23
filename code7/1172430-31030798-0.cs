    Dictionary<string, Dictionary<string, List<string>>> dict =
        new List<Tuple<string, string, string>>().GroupBy(item => item.Item1)
            .ToDictionary(
                groupedByItem1 => groupedByItem1.Key,
                groupedByItem1 =>
                groupedByItem1.GroupBy(item => item.Item2)
                    .ToDictionary(
                        groupedByItem2 => groupedByItem2.Key,
                        groupedByItem2 => groupedByItem2.Select(item => item.Item3).ToList()));
