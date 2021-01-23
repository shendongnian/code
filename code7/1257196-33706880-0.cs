    public class Program {
        public int ProgramId { get; set; }
        public virtual ICollection<ProgramGroup> ProgramGroups { get; set; }
    }
    
    public class Group {
        public int GroupId { get; set; }
        public virtual ICollection<ProgramGroup> ProgramGroups { get; set; }
    }
