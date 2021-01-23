    public class ProjectExtra : IModel
    {
        [DataMember]
        public int ProjectID { get; set; }
        [DataMember]
        public string Description { get; set; }
        
        // navigation property to Project
        [IgnoreDataMember]
        public virtual Project Project { get; set; } 
    }
