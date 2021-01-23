    public class BaseMap<T> : ClassMap<T> where T : Address
    {
        public BaseMap()
        {
            Id(x => x.Id);
            Map(x => x.IsActive);
            Map(x => x.CreateDate);
        }
    }
    
    public class SomeEntityMap: BaseMap<SomeEntity>
    {
        public CustomerAddressMap()
        {
            Table("SomeTable");
            Map(x => x.SomeProperty);
        }
    }
    public class Entity
    {
       public virtual Guid Id { get; set; }
       public virtual bool IsActive { get; set; }
       public virtual DateTime CreateDate { get; set; }
    }
    public class SomeEntity : Entity
    {
       public virtual string SomeProperty { get; set; }
    }
