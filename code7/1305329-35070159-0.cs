    public class ClubMember 
    {
        protected bool Equals(ClubMember other)
        {
            return MemberId.Equals(other.MemberId) && string.Equals(FullName, other.FullName) && MemberSince.Equals(other.MemberSince);
        }
        public Guid MemberId { get; set; }
        public string FullName { get; set; }
        public DateTime MemberSince { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ClubMember) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = MemberId.GetHashCode();
                hashCode = (hashCode*397) ^ (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ MemberSince.GetHashCode();
                return hashCode;
            }
        }
    }
