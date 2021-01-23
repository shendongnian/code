    public class ApplicationUserRelationship
    {
        public virtual ApplicationUser OwningUser { get; set; }
        public virtual ApplicationUser DependentUser { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }
        public virtual DateTime? CreatedDateTime { get; set; }
        public virtual DateTime? UpdatedDateTime { get; set; }
        ...
    }
