    public class Item
    {
        public virtual int Id { get; protected set; }
        public virtual IList<Resource> Resources { get; protected set; }
        // Constructor, Equals, GetHashCode, other things ... omitted.
    }
    public class Resource
    {
        public virtual Item Owner { get; protected set; }
        public virtual int ResourceId { get; protected set; }
        public virtual string Locale { get; protected set; }
        public virtual string Value { get; protected set; }
        // Constructor, Equals, GetHashCode, other things ... omitted.
    }
    
