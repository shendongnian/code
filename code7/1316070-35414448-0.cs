    using System.Diagnostics.Eventing.Reader;
    
    string logType = "Microsoft-Windows-TerminalServices-RemoteConnectionManager/Operational";
    string query = "*[System/EventID=1149]";
    
    var elQuery = new EventLogQuery(logType, PathType.LogName, query);
    var elReader = new EventLogReader(elQuery);
    
    for (EventRecord eventInstance = elReader.ReadEvent(); eventInstance != null; eventInstance = elReader.ReadEvent())
    {
          // .. do stuff here
    }
