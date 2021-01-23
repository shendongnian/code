    public class Category
    {
      public virtual ICollection<Movie>() Movies { get; set; }
      public string Name { get; set;}
      public Category(string name)
      {
        Name = name;
      }
    }
