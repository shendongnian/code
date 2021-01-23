    public interface ISupportsDirtyChecking
    {
         bool IsDirty { get; }
    }
    
    public class User : ISupportsDirtyChecking
    {
        public int Id { get; set; };
        public bool IsDirty => Id == 0; 
    }
