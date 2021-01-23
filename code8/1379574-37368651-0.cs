    public abstract class Base
    {
        public Guid Id { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
    
    public sealed class Derived : Base
    {
        public string Name { get; set; }
    }
