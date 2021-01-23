    var iterations = 1000000;
    
    var lst = new List<string>();
    
    var rnd = new Random();
    var dblArray = new double[iterations];
    var dmArray = new decimal[iterations];
    for (var i = 0; i < iterations; i++)
    {
        dblArray[i] = rnd.NextDouble();
        dmArray[i] = (decimal)dblArray[i];
    }
    
    var sw = new Stopwatch();
    sw.Start();
    for (var i = 0; i < iterations; i++)
        lst.Add(i.ToString());
    sw.Stop();
    //takes 154 MS
    Debug.WriteLine("Double loop MS: " + sw.ElapsedMilliseconds);
    
    //reset list
    lst = new List<string>();
    sw.Restart();
    for (var i = 0; i < iterations; i++)
        lst.Add(i.ToString());
    sw.Stop();
    //takes 193 MS
    Debug.WriteLine("Decimal loop MS: " + sw.ElapsedMilliseconds);
