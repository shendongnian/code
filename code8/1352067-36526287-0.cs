    Stopwatch Watch = new Stopwatch();
    long tList = 0, tHset = 0; // ms
    // measure time to look up string in ordinary list
    Watch.Start();
    foreach ( string Str in Copy )
    {
        if ( ListVersion.Contains(Str) ) { }
    }
    Watch.Stop();
    tList = Watch.ElapsedMilliseconds;
    // now measure time to look up same string in my hash set
    Watch.Reset();
    Watch.Start();
    foreach ( string Str in Copy )
    {
        if ( this.Contains(Str) ) { }
    }
    Watch.Stop();
    tHset = Watch.ElapsedMilliseconds;
    Console.WriteLine("Total milliseconds to look up in List: {0}", tList);
    Console.WriteLine("Total milliseconds to look up in hashset: {0}", tHset);
