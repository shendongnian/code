    public class Member
    {
        public int MemberID { get; set; }
        public int FamilyID { get; set; }
        [ForeignKey("FamilyID")]
        public virtual Family Family { get; set; }
    }
