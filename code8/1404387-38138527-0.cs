    var random = new Random();
    
    var values = new HashSet<decimal>();
    int i = 10000000;
    var sw = Stopwatch.StartNew();
    decimal epsilon = 0.1m;
    while (i-- > 0)
    {
    	var value = (decimal)random.NextDouble();
        // assume values below .1 are zero.
    	if (value - epsilon > 0)
    		values.Add(value);
    }
    sw.ElapsedMilliseconds.Dump("create");
    sw.Reset();	
    values.Count().Dump(Convert.ToString(sw.ElapsedMilliseconds));
    values.Sum().Dump(Convert.ToString(sw.ElapsedMilliseconds));
