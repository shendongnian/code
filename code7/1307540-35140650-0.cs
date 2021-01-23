    var sessionMaster = Dictionary<string, Session>();
    
    sessionMaster.Add("1", new Session(){SessiongLogs= new List<string>(){"a", "b"}};
    sessionMaster.Add("2", new Session(){SessiongLogs= new List<string>(){"c", "d"}};
    
    var sid = "1";
    var line = "testLine"
    sessionMaster[sid]?.SessionLog.Add(line);
    
