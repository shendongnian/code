    public class Family
    {
        public Family()
        {
            FamilyMembers = new HashSet<Member>();
        }
        public int FamilyID { get; set; }
        public virtual ICollection<Member> FamilyMembers { get; set; }
    }
