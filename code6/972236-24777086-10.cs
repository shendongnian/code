       public class Tag : IEquatable<Tag>
        {
            public Tag()
            {
                Maps = new HashSet<Map>();
            }
    
            public int Id { get; set; }
            public string Text { get; set; }
            public virtual ISet<Map> Maps { get; private set; }
    
            public bool Equals(Tag other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Id == other.Id;
            }
    
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Tag) obj);
            }
    
            public override int GetHashCode()
            {
                return Id;
            }
    
            public static bool operator ==(Tag left, Tag right)
            {
                return Equals(left, right);
            }
    
            public static bool operator !=(Tag left, Tag right)
            {
                return !Equals(left, right);
            }
        }
