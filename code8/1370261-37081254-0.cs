    var iterations = 1000000;
    var lst = new List<string>();
    
    var sw = new Stopwatch();
    sw.Start();
    for (double i = 0; i < iterations; i++)
        lst.Add(i.ToString());
    sw.Stop();
    //takes 254 MS
    Debug.WriteLine("Double loop MS: " + sw.ElapsedMilliseconds);
    
    //reset list
    lst = new List<string>();
    
    sw.Start();
    for (decimal i = 0; i < iterations; i++)
        lst.Add(i.ToString());
    sw.Stop();
    //takes 515 MS
    Debug.WriteLine("Decimal loop MS: " + sw.ElapsedMilliseconds);
