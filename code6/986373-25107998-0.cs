    public sealed class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("dbo.Employee");
            Id(x => x.Id).Column("EmployeeId");
            Map(x => x.Name);
            Map(x => x.Job);
            HasMany(x => x.Phones).KeyColumn("EmployeeId").Table("dbo.Phone").Inverse().Cascade.AllDeleteOrphan();
        }
    }
    public sealed class PhoneMap : ClassMap<Phone>
    {
        public PhoneMap()
        {
            Table("dbo.Phone");
            Id(x => x.Id).Column("PhoneId");
            Map(x => x.PhoneNumber);
            Map(x => x.PhoneType);
            Map(x => x.EmployeeId);
            References(x => x.Employee, "EmployeeId");
        }
    }
