        public class Continent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Country> Countries { get; set; }
    }
    public class Country
    {
        public string Name { get; set; }
        public List<Province> Provinces { get; set; }
    }
    public class Province
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
    public class City
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
