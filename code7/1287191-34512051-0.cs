    public class Company
    {
        public virtual ICollection<BusinessUnit> BusinessUnits { get; protected set; }
    
        public int Id { get; protected set; }
    }
    
    public class BusinessUnit
    {
        public virtual Company Company { get; protected set; }
    
        public int CompanyId { get; protected set; }
    
        public string Description { get; protected set; }
    }
