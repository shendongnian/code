    public class UsageType : IEquatable<UsageType>
    {
        public int UsageTypeId {get; set;}
        ...
        public bool Equals(UsageType other)
        {
           return this.UsageTypeId == other.UsageTypeId;
        }
        public override bool Equals(object other)
        {
           return this.UsageTypeId == ((UsageType)other).UsageTypeId;
        }
        public override int GetHashCode()
        { 
           return this.UsageTypeId.GetHashCode();
        }
    }
