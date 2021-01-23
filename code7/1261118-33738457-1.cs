    public static void SlotDemo()
    {
        DateTime startTime = DateTime.Today;
        DateTime endTime = startTime.Add(new TimeSpan(0, 10, 20));
    
        List<TimeSlot> segments = new List<TimeSlot>();
        segments.Add(new TimeSlot(startTime.Add(new TimeSpan(0, 2, 30)), new TimeSpan(0, 1, 13)));
        segments.Add(new TimeSlot(startTime.Add(new TimeSpan(0, 4, 25)), new TimeSpan(0, 0, 35)));
        segments.Add(new TimeSlot(startTime.Add(new TimeSpan(0, 7, 21)), new TimeSpan(0, 2, 34)));
    
        for (int i = 0; i < segments.Count; i++)
        {
            Console.WriteLine("s: {0:mm':'ss}  d: {1:mm':'ss}  e: {2:mm':'ss}", segments[i].Start, segments[i].Span, segments[i].End);
        }
        Console.WriteLine();
    
        if (!segments[0].Start.Equals(startTime))
        {
            TimeSlot firstSlot = new TimeSlot(startTime, segments[0].Start.Subtract(startTime));
            segments.Insert(0, firstSlot);
        }
    
        for (int i = 0; i < segments.Count; i++)
        {
            Console.WriteLine("s: {0:mm':'ss}  d: {1:mm':'ss}  e: {2:mm':'ss}", segments[i].Start, segments[i].Span, segments[i].End);
        }
        Console.WriteLine();
    
        for (int i = 0; i < segments.Count - 1; i++)
        {
            if (segments[i].End != segments[i + 1].Start)
            {
                TimeSlot slot = new TimeSlot(segments[i].End, segments[i + 1].Start.Subtract(segments[i].End));
                segments.Insert(i + 1, slot);
                i++;
            }
        }
    
        for (int i = 0; i < segments.Count; i++)
        {
            Console.WriteLine("s: {0:mm':'ss}  d: {1:mm':'ss}  e: {2:mm':'ss}", segments[i].Start, segments[i].Span, segments[i].End);
        }
        Console.WriteLine();
    
        int lastIndex = segments.Count - 1;
        if (!segments[lastIndex].End.Equals(endTime))
        {
            TimeSlot lastSlot = new TimeSlot(segments[lastIndex].End, endTime.Subtract(segments[lastIndex].End));
            segments.Add(lastSlot);
        }
    
        for (int i = 0; i < segments.Count; i++)
        {
            Console.WriteLine("s: {0:mm':'ss}  d: {1:mm':'ss}  e: {2:mm':'ss}", segments[i].Start, segments[i].Span, segments[i].End);
        }
        Console.ReadKey();
    }
