    var arr = Enumerable.Range(0, 20000).Select(x => x.ToString()).ToArray();
    var t1 = Measure(()=>{
                var blocks = arr
                            .Select((s, i) => new { s, i })
                            .GroupBy(x => x.i / 25)
                            .Select(g => String.Join(" ", g.Select(x => x.s)))
                            .ToList();
            },1000);
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
    Console.WriteLine("EZI:" + t1  + " Shar1er80:" + t2 + " Modified-EZI:" + t3);
