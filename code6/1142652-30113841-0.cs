    public class Organization
    {
      public string Name { get; set;} 
      public IEnumerable<Category> Categories { get; set; }
    }
    public class Category
    {
      public string Name { get; set; }
    }
