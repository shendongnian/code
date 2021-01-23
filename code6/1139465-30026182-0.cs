    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            HasManyToMany(x => x.IndustryTypes)
               .Cascade.All()
               .Table("CompaniesIndustryTypes");
        }
    }
    
    public class IndustryTypeMap : ClassMap<IndustryType>
    {
        public IndustryTypeMap()
        {
            HasManyToMany(x => x.Companies)
               .Cascade.All()
               .Inverse()
               .Table("CompaniesIndustryTypes");
        }
    }
