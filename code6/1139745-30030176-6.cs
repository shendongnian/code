    public interface INamed {
         string Name { get; set; }
    }
    public class Car : INamed {
         public int Id { get; set; }
         public string Name { get; set; }
    }
