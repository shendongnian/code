	public class ProjectViewModel
    {
        public string SelectedProjectKey { get; set; }	// string may need to be int depending on what type ProjectKey is in your class
        public ICollection<Project> Projects { get; set; }
    }
	
