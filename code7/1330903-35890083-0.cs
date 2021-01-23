    ParallelMeasurements.Add(new Tuple<string, TimeSpan>("Actor.ActorUsers", TimeSpan.FromMilliseconds(150)));
    ParallelMeasurements.Add(new Tuple<string, TimeSpan>("Actor.ActorInformation", TimeSpan.FromMilliseconds(200)));
    ParallelMeasurements.Add(new Tuple<string, TimeSpan>("User.Edit", TimeSpan.FromMilliseconds(150)));
    var folders =
        ParallelMeasurements.Select(
            s =>
            new
                {
                    Folder = s.Item1,
                    Group = s.Item1.Substring(0, s.Item1.IndexOf(".", StringComparison.InvariantCulture)),
                    Sum = s.Item2.TotalMilliseconds
                })
            .GroupBy(g => g.Group)
            .Select(s => new { Group = s.Key, Sum = s.Sum(a => a.Sum) })
            .ToList();
    var folderResult = string.Join(",", folders.Select(f => f.Group));
    var valueResult = string.Join(",", folders.Select(f => f.Sum));
    Console.WriteLine("{0}{1}{2}", folderResult, Environment.NewLine, valueResult);
    Console.ReadKey();
