    var section = ConfigurationManager.GetSection("jobSection");
    if (section != null)
    {
        var jobs = (section as JobSection).Jobs;
        var query = 
           from JobElement je in jobs 
           where je.Name == "Job Name A" 
           select je.Id;
        var item = query.Single();
        Console.WriteLine(item.ToString());
    }
