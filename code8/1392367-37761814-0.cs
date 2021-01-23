    Dictionary<SteatType, IProcessor> processors = new Dictionary<SteatType, IProcessor>();
    
    for (int i = 0; i < buses.Length; i++)
    {
        Bus b = buses[i];
        IProcessor p = processors[b];
        // p.process(b);
    }
