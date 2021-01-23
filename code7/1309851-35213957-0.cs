    public class Member
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime MemberSince { get; set; }
        public override int GetHashCode()
        {
            // if each member has a unique Id assigned to him/her
            // you can simply return Id
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var member = (Member)obj;
            return member == null
                ? false
                : Id == member.Id;
        }
    }
