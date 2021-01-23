    public class Entity : IEquatable<Entity>
    {
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EntityId == other.EntityId && 
                   string.Equals(EntityName, other.EntityName);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity) obj);
        }
        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !Equals(left, right);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (EntityId*397) ^ (EntityName != null ? EntityName.GetHashCode() : 0);
            }
        }
    }
