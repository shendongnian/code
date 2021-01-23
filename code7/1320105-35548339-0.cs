    public class UsageType : IEquatable<UsageType>
    {
        public int UsageTypeId {get; set;}
        ...
        public bool Equals(UsageType other)
        {
           return this.UsageTypeId == other.UsageTypeId;
        }
    }
