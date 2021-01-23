    // Assuming you want an instance of ProtocolSummary
    var protocolSummary = new ProtocolSummary()
    {
    MasteredTask = "Some Mastered task name",
    NewTask = "Here goes new task",
    ATList  = new List<AssistTech>() 
    {
    new AssistTech() { Type  = "Some text", ScheduleForUse  = "Some other text", StorageLocation  = "Some other other text" },
    new AssistTech() { Type  = "Some text", ScheduleForUse  = "Some other text", StorageLocation  = "Some other other text" }
    }
    };
