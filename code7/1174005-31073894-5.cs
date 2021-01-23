    const int Iterations = 100000;
    var sw = new Stopwatch();
    var sum1 = 0;
    sw.Start();
    for (int i = 0; i < Iterations; i++)
    {
        try
        {
            var s = int.Parse("s" + i);
            sum1 += s;
        }
        catch (Exception)
        {
        }
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
    Console.WriteLine(sum1);
    var sw2 = new Stopwatch();
    var sum2 = 0;
    sw2.Start();
    for (int i = 0; i < Iterations; i++)
    {
        try
        {
            int s;
            if (int.TryParse("s" + i, out s))
                sum2 += s;
        }
        catch (Exception)
        {
        }
    }
    sw2.Stop();
    Console.WriteLine(sw2.ElapsedMilliseconds);
    Console.WriteLine(sum2);
