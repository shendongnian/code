    EventLogReader log2 = new EventLogReader("Microsoft-Windows-TaskScheduler/Operational");
    
    for (EventRecord eventInstance = log2.ReadEvent(); null != eventInstance; eventInstance = log2.ReadEvent())
    {
        if (!eventInstance.Properties.Select(p => p.Value).Contains("\\{YOUR SCHEDULED TASK NAME}}"))
        {
            continue;
        }
        
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Event ID: {0}", eventInstance.Id);
        Console.WriteLine("Publisher: {0}", eventInstance.ProviderName);
        try
        {
            Console.WriteLine("Description: {0}", eventInstance.FormatDescription());
        }
        catch (EventLogException)
        {
        }
        EventLogRecord logRecord = (EventLogRecord)eventInstance;
        Console.WriteLine("Description: {0}", logRecord.FormatDescription());
    }
