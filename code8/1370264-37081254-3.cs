    var iterations = 1000000;
    
    var lst = new List<string>();
    
    var rnd = new Random();
    var dblArray = new double[iterations];
    for (var i = 0; i < iterations; i++)
        //INTERESTING FINDING FROM THE COMMENTS
        //double.ToString() is faster if this line is rnd.NextDouble()
        //but decimal.ToString() is faster if hard-coding the value "3.5" 
        //(despite the overhead of casting to decimal)
        dblArray[i] = rnd.NextDouble();
    
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
        lst.Add(((decimal)dblArray[i]).ToString());
    sw.Stop();
    //takes 280-320 MS
    Debug.WriteLine("Decimal loop MS: " + sw.ElapsedMilliseconds);
