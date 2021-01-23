    public class ClientViewModel
    {
       // Properties
    }
    
    public class ProjectViewModel
    {
       // Properties
    }
    
    public class EditViewModel
    {
        public ClientViewModel Client { get; set; }
        public IList<ProjectViewModel> Projects { get; set; }
    }
