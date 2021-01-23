    public interface IPersistible
    {
         bool IsNew { get; }
    }
    
    public class User : IPersistible
    {
        public int Id { get; set; };
        public bool IsNew => Id == 0; 
    }
