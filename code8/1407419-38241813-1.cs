    int stepSize = 2000;
    long start = DateTime.Now.Ticks;
    for (int i = 0; i < Math.Ceiling((double)count / stepSize); i++)
    {
        List<MyDocument> list = collection.Find(query).SetSkip(i * stepSize).SetLimit(stepSize).ToList();
    }
    long end = DateTime.Now.Ticks;
    Debug.WriteLine("Step 2000 --> " + new TimeSpan(end - start));
    // Step 2000 --> 00:00:42.1772173
