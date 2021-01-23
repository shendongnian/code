    public class Root
    {
        [Key]
        public int RootId { get; set; }
        public string RootName { get; set; }
        [InverseProperty("Root")]
        public ICollection<Node> Nodes { get; set; }
    }
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
        public string NodeName { get; set; }
        [ForeignKey("Root")]
        public int RootId { get; set; }
        public Root Root { get; set; }
    }
