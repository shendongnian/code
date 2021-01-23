    public class Project
    {
        public Guid ProjectId { get; set; }
    
        public virtual TeamMember Manager { get; set; } // 2
    
        [InverseProperty("Projects")]
        public virtual List<TeamMember> TeamMembers { get; set; } // 1
    }
    
    public class TeamMember
    {
        public Guid TeamMemberId { get; set; }
    
        [InverseProperty("TeamMembers")]
        public virtual List<Project> Projects { get; set; } // 1
    
        [InverseProperty("Manager")]
        public virtual List<Project> ManagedProjects { get; set; } // 2
    }
