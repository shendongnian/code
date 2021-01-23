    public interface IUniquelyIdentifiable
    {
         int Id { get; set; }
    }
    
    public class Author : IUniquelyIdentifiable
    {
         public int Id { get; set; }
         // ...and the rest of properties
    }
