    var policies = new XElement("Policies");
    var test = new XDocument(new XElement("NBUConfig", policies));
    
    // Hint: for loops are more idiomatic than while loops here
    for (int pcount = 0; pcount < 3; pcount++)
    {
        var schedules = new XElement("Schedules");
        for (int scount = 0; scount < 3; scount++)
        {
            schedules.Add(new XElement("Schedule",
                new XAttribute("Number", scount),
                new XElement("ScheduleStuff", scount));
        }
        policies.Add(new XElement("Policy",
            new XElement("PolicyName", pcount),
            new XElement("General"),
            new XElement("Clients"),
            new XElement("IncludeList"),
            schedules));        
    }
