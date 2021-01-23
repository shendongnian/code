    public partial class CountryRegionHeader
    {
        public CountryRegionHeader()
        {
           StateProvinces = new HashSet<StateProvinceTlb>();
        }
        public string CountryRegionCode { get; set; }
        public string Name { get; set; }
    }
    public partial class CountryRegionDetail
    {
        public CountryRegionDetail()
        {
            StateProvinces = new HashSet<StateProvinceTlb>();
        }
        public string CountryRegionCode { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<StateProvince> StateProvinces { get; set;}
        pubic virtual CountryRegion CountryRegion {get;set;}
    }
