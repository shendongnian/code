    var section = ConfigurationManager.GetSection("jobSection");
    if (section != null)
    {
        var jobs = (section as JobSection).Jobs;
        var item = jobs.Cast<JobElement>()
                       .First(je => je.Name == "Job Name A");
        Console.WriteLine(item.Id);
    }
