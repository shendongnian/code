    public class UserGroupMap :  IEquatable<UserGroupMap>
    { 
        public string UserId {get;set;}
        public string GroupId { get; set; }
        public string FormGroupFlag { get; set; }
        public string GroupDescription { get; set; }
        public string GroupName { get; set; }
    
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
    
                hash = hash * 23 + (UserId ?? "").GetHashCode();
                hash = hash * 23 + (GroupId ?? "").GetHashCode();
                hash = hash * 23 + (FormGroupFlag ?? "").GetHashCode();
                hash = hash * 23 + (GroupDescription ?? "").GetHashCode();
                hash = hash * 23 + (GroupName ?? "").GetHashCode();
    
                return hash;
            }
        }
    
        public bool Equals(UserGroupMap other)
        {
            if(other == null) return false;
            if(Object.ReferenceEquals(this, other)) return true;
    
            return this.UserId == other.UserId
                && this.GroupId == other.GroupId
                && this.FormGroupFlag == other.FormGroupFlag
                && this.GroupDescription == other.GroupDescription
                && this.GroupName == other.GroupName;
        }    
    }
