    public class ProjectWrapper
    {  
        public Project Project { get; set; }
    }
    
    var projectsList = ser.Deserialize<List<ProjectWrapper>>(jsonString)
      .Select(p => p.Project).ToList();
