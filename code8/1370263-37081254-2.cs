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
        lst.Add(dblArray[i].ToString());
    sw.Stop();
    //takes 280-300 MS
    Debug.WriteLine("Double loop MS: " + sw.ElapsedMilliseconds);
    
    //reset list
    lst = new List<string>();
    sw.Restart();
    for (var i = 0; i < iterations; i++)
        lst.Add(dmArray[i].ToString());
    sw.Stop();
    //takes 280-320 MS
    Debug.WriteLine("Decimal loop MS: " + sw.ElapsedMilliseconds);
