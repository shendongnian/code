    public class LocalUser
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class Company
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual LocalUser OwnerUserId { get; set; }
    }
    public class LocalUserMap : ClassMap<LocalUser>
    {
        public LocalUserMap()
        {
            Table("[User]");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
        }
    }
