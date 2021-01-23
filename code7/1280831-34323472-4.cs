    List<T1> list = new List<T1>();
    Random rnd = new Random();
    for (int i = 0; i < 10000; i++)
    {
        list.Add(new T1 { param = rnd.Next(1,5000).ToString()});
    }
    Stopwatch sw = Stopwatch.StartNew();
    var result1 =
        list
            .GroupBy(x => x.param)
            .Where(x => x.Count() > 1)
            .SelectMany(x => x)
            .ToList();
    long result1_time = sw.ElapsedMilliseconds;
    sw.Restart();
    var result2 = list.Where(el => list.Any(z => z.param == el.param && z != el)).ToList();
    long result2_time = sw.ElapsedMilliseconds;
    Console.WriteLine(result1_time);
    Console.WriteLine(result2_time);
    Console.ReadLine();
