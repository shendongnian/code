    public class City
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
    
      public City Clone()
      {
        return (City)MemberwiseClone();
      }
    
    }
    
    public class MyDbContext : DbContext
    {
      public MyDbContext(string connectionString)
            : base("name=" + connectionString)
      {
      }
    
      public DbSet<City> Cities { get; set; }
    }
    
    public static void Main(string[] args)
    {
      Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
    
      using (var myDbContext = new MyDbContext())
      {
        // This will add the city one time  => the bug
        var city = new City();
    
        var list = new List<City>();
        list.Add(city);
        list.Add(city);
    
        myDbContext.Cities.AddRange(list);
        myDbContext.SaveChanges();
    
        // This will add the city 2 times
        city = new City();
        var city2 = new City();
    
        list = new List<City>();
        list.Add(city);
        list.Add(city2);
    
        myDbContext.Cities.AddRange(list);
        myDbContext.SaveChanges();
    
        // This will add the clonned city1 and city=> Fix!
        var cityCloned1 = city.Clone();
        var cityCloned2 = city2.Clone();
    
        list = new List<City>();
        list.Add(cityCloned1);
        list.Add(cityCloned2);
    
        myDbContext.Cities.AddRange(list);
        myDbContext.SaveChanges();
    
      }
    
    }
