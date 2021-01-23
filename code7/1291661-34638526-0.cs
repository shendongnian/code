    public class SomeEntity : ISomeEntity {
      public int Id { get; set; }
      public string Name { get; set; }
    }
    
    public interface ISomeEntity {
      int Id { get; set; }
      string Name { get; set; }
    }
