    PersistantQueue list = new PersistantQueue("queuefolder");
    foreach (var i in Enumerable.Range(1, 100000))
    {
        list.Add(i + "_" + Guid.NewGuid());
        if(i % 1000 == 0)
            Console.WriteLine("c: "+ DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss:fff ->") + i);
    }
    
    string msg = null;
    int b = 0;
    while ((msg = list.GetNext()) != null)
    {
        b++;
    
        if (b % 1000 == 0)
            Console.WriteLine("r: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss:fff ->") + b);
    }
    Console.WriteLine("done");
