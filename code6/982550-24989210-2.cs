    public class ApplicationUserRelationship
    {
        public virtual ApplicationUser LeftUser { get; set; }
        public virtual ApplicationUser RightUser { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }
        public virtual DateTime? CreatedDateTime { get; set; }
        public virtual DateTime? UpdatedDateTime { get; set; }
        ...
    }
