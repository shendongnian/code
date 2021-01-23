    public class Project
        {
            public Project { 
                Members = new HashSet<ProjectMember>(); 
            }
            public Guid Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<ProjectMember> Members { get; set; }
        }
        
        public class ProjectMember
        {
            public Guid ProjectId { get; set; }
            public virtual Project Project { get; set; }
        
            public Guid CityId { get; set; }
            public virtual City City { get; set; }
        }
