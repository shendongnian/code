    public interface IObjectState
    {
         bool IsNew { get; }
    }
    
    public class User : IObjectState
    {
        public int Id { get; set; };
        public bool IsNew => Id == 0; 
    }
