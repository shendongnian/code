    public class Member
    {
        public int MemberID { get; set; }
        public int FamilyID { get; set; }  // EF will automatically make this a FK by convention
        public virtual Family Family { get; set; }
    }
