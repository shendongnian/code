    public interface IPersistable
    {
         bool IsNew { get; }
    }
    
    public class User : IPersistable
    {
        public int Id { get; set; };
        public bool IsNew => Id == 0; 
    }
