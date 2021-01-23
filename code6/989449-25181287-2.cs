    var processes = companies1.SelectMany(
    c => c.compnKeyProcesses1.Split(new char[] { ',' }).Select(s => s.Trim()).Distinct())
    .GroupBy(s => s).ToDictionary(g => g.Key, g => g.Count());
    foreach(var process in processes)
    {
        Console.WriteLine("\"{0}\" appears in {1} names", process.Key, process.Value);
    }
