    public class ParentMemberVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        .... other properties to display
        public IEnumerable<MemberVM> Members { get; set; }
        public IEnumerable<SelectListItem> RelationshipList { get; set; }
    }
    public class MemberVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Relationship { get; set; }
    }
