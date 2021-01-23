    public class Continent
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public virtual ICollection<Country> Country{get;set;}//Add this property
    }   
    
    public class Country
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public int ContinentId { get; set; }
      public virtual Continent Continent{get;set;}//Add this property
      public virtual ICollection<Cities> Cities{get;set;}//Add this property
    }
    public class City
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public int CountryId { get; set; }
      public virtual Country Country{get;set;}//Add this property
    }
