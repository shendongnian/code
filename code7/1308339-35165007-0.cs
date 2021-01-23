    var changeList = new PackageHistory(devicePackageHistory
        .SelectMany(x => x.Value.Select(y => new Tuple<string, string, DateTime>(x.Key, y.Item1, y.Item2)))
        .Except(databasePackageHistory.SelectMany(x => x.Value.Select(y => new Tuple<string, string, DateTime>(x.Key, y.Item1, y.Item2))))
        .GroupBy(x => x.Item1)
        .ToDictionary(x => x.Key, x => x.Select(y => new Tuple<string, DateTime>(y.Item2, y.Item3)).ToList()));
