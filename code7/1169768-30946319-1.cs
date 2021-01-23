    var configuration = db.ConfigurationsOrSomething
        .Include(c => c.CPU)
        .Where(c => c.DeletedOrWhatever == false)
        .ToList();
    
    var cpu = configuration.CPU;
    
    if(cpu == null)
        Debug.WriteLine("Something else is the problem. :(");
