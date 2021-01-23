    public class Node
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
    }
    public class HierarchicalNode
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public List<HierarchicalNode> Children { get; set; }
    }
