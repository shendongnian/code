    long start = DateTime.Now.Ticks;
    foreach (MyDocument item in collection.Find(query))
    {
    }
    long end = DateTime.Now.Ticks;
    Debug.WriteLine("Step 1 --> " + new TimeSpan(end - start));
    // Step 1 --> 00:00:39.6329629
