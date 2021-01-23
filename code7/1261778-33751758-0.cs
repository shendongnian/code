    public class Node
    {
        public int node_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public object node_name { get; set; }
        public string node_type_id { get; set; }
        public int parent_node_id { get; set; }
        public int display_order { get; set; }
        public int display_in_list { get; set; }
        public int lft { get; set; }
        public int rgt { get; set; }
        public int depth { get; set; }
        public int style_id { get; set; }
        public int effective_style_id { get; set; }
    }
    public class RootObject
    {
        public int count { get; set; }
        public Dictionary<string, Node> nodes { get; set; }
    }
