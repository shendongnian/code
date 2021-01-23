    public class Property
    {
        public string Name { get; set; }
        [XmlElement("Building")]
        public List<Building> Buildings { get; set; }
        public Property()
        {
            Buildings = new List<Building>();
        }
    }
    public class Building
    {
        public string Name { get; set; }
        [XmlElement("Tenant")]
        public List<Tenant> Tenants { get; set; }
        public Building()
        {
            Tenants = new List<Tenant>();
        }
    }
    public class Tenant
    {
        public string Name { get; set; }
        [XmlAttribute("SquareFeet")]
        public int SF { get; set; }
        public decimal Rent { get; set; }
    }
