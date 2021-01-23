    public class Group
    {
        public int Id {get; set;}
        public ICollection<Group> IsMemberOf { get; set; }
        public ICollection<Group> HasMembers { get; set; }
    }
