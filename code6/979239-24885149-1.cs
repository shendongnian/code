    wa = new WorkAllocator(10);
    if (wa.WorkPackets != null && wa.WorkPackets.Count > 0)
    {
        var tasks = new List<Task>();
        foreach (WorkPacket wp in wa.WorkPackets)
        {
            tasks.Add(Task.Run(() =>
                {
                    Processor.Run(wp);
                });
        }
    
        Task.WaitAll(tasks.ToArray());
    }
