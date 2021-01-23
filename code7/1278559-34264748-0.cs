    public class Organization
    {
        public String Id  { get; set; }
        public virtual ICollection<OrganizationGroup> OrganizationGroups { get; set; }
    }
    public class OrganizationGroup
    {
        public String Id { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
    }
