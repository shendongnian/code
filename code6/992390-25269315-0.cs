    public enum CompanyType
    {
      Agent = 0,
      Supplier
    }
    
    public abstract class Company : Entity<Company>
    {
       public CompanyIdentifier Id { get; private set; }
       public string Name { get; private set; }
       public CompanyType EntityType { get; private set; }
       public abstract void Invoice();
       public abstract void GetCommission(int month);
       ...
