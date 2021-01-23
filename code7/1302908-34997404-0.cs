     public class Job
        {
            public string Category { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string ShortDescription { get; set; }
            public string Benefits { get; set; }
            public string Jobtype { get; set; }
            public List<JobLocation> JobLocations { get; set; }
    
            public class JobLocation
            {
                public string Location { get; set; }
                public string Salary { get; set; }
            }
    
            public static List<Job> Load(string path)
            {
                static XDocument xdoc = XDocument.Load(path);
                return xdoc.Descendants("Job")
                           .Select(x => new Job
                           {
                               Category = (string)x.Attribute("Category"),
                               Title = (string)x.Attribute("Title"),
                               Description = (string)x.Element("Description"),
                               ShortDescription = (string)x.Element("ShortDescription"),
                               Benefits = (string)x.Element("Benefits"),
                               Jobtype = (string)x.Element("Jobtype"),
                               JobLocations = x.Element("JobLocations").Elements("Location")
                                               .Select(jl => new JobLocation
                                               {
                                                   Location = (string)jl,
                                                   Salary = (string)jl.Attribute("Salary")
                                               }).ToList()
                           }).ToList();
            }
        }
