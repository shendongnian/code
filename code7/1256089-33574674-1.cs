    var processes = new List<ProcessInformation>
                    {
                        new ProcessInformation("P0", 0, 3),
                        new ProcessInformation("P1", 0, 4),
                        new ProcessInformation("P2", 0, 5),
                        new ProcessInformation("P3", 1, 1),
                        new ProcessInformation("P4", 1, 3)
                    };
    int currentTime = 0;
    while (processes.Any(p => p.TimeLeft > 0))
    {
        var shortest =
            processes.Where(p => p.ArrivalTime <= currentTime && p.TimeLeft > 0)
                .OrderBy(p => p.TimeLeft)
                .FirstOrDefault();
        if (shortest != null)
        {
            if (shortest.StartTime == null) shortest.StartTime = currentTime;
            shortest.TimeLeft--;
            if (shortest.TimeLeft == 0) shortest.EndTime = currentTime + 1;
        }
        currentTime++;
    }
    foreach (var p in processes)
    {
        Console.WriteLine(
            "Process {0} arrived {1} started {2} ended {3} duration {4} wait {5}", 
            p.Name, 
            p.ArrivalTime, 
            p.StartTime, 
            p.EndTime, 
            p.Duration, 
            p.EndTime - p.ArrivalTime - p.Duration);
    }
