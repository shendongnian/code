    const Int32 numberOfRows = 200000;
    var inputData = GetInputData(numberOfRows);
    var results = new Dictionary<string, IList<int>>(numberOfRows);
    var hashSet = new HashSet<string>();
    var sw = Stopwatch.StartNew();
    foreach (var dataItem in inputData)
    {
        if (hashSet.Add(dataItem.Item2))
        {
            results.Add(dataItem.Item2, new List<int>() {dataItem.Item1});
        }
        else
        {
            results[dataItem.Item2].Add(dataItem.Item1);
        }
    }
    Console.WriteLine(sw.ElapsedMilliseconds);
