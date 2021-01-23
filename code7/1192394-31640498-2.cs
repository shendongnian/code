    var arr = Enumerable.Range(0, 20000).Select(x => x.ToString()).ToArray();
    var t1 = Measure(() =>
    {
        var blocks = arr
                    .Select((s, i) => new { s, i })
                    .GroupBy(x => x.i / 25)
                    .Select(g => String.Join(" ", g.Select(x => x.s)))
                    .ToList();
    }, 1000);
    var t2 = Measure(() =>
    {
        var allLines = new List<string>();
        for (int i = 0; i < arr.Length; i += 25)
        {
            allLines.Add(String.Join(" ", arr.Skip(i).Take(25)));
        }
    }, 1000);
    var t3 = Measure(() =>
    {
        int count = 0;
        var blocks = arr
                    .GroupBy(x => count++ / 25)
                    .Select(g => String.Join(" ", g))
                    .ToList();
    }, 1000);
    var t4 = Measure(() =>
    {
        var blocks = arr.Batch(25, x => x)
                    .Select(g => String.Join(" ", g))
                    .ToList();
    }, 1000);
    Console.WriteLine("EZI: {0}\nShar1er80: {1}\nModified-EZI: {2}\nMoreLinq'sBatch: {3}", t1,t2,t3,t4);
---
    long Measure(Action action, int n)
    {
        action();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < n; i++)
        {
            action();
        }
        return sw.ElapsedMilliseconds;
    }
