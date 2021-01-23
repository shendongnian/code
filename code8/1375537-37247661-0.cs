    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public string Name
        {
            get
            {
                return Project.Name;
            }
        }
        public int Priority
        {
            get
            {
                return Project.Priority;
            }
        }
        public IList Children
        {
            get
            {
                if (Project.Projects.Count > 0)
                {
                    return Project.Projects;
                }
                return Project.Tasks;
            }
        }
    }
