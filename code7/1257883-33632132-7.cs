    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    } 
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }
        public virtual Continent Continent { get; set; }
        public virtual ICollection<City> Cities { get; set; } 
    }
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
