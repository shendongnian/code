    [DataContract(Name = "project", Namespace="")]
    public class Project
    {
        [DataMember(Name = "title",Order=1)]
        public string Title { get; set; }
        [DataMember(Name = "nodes", Order=2)]
        public NodeCollection Nodes { get; set; }
    }
    [CollectionDataContract(Name = "nodes",Namespace="", ItemName = "node")]
    public class NodeCollection : List<Node> {  }
    [DataContract(Name = "node", Namespace="")]
    public class Node
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "class")]
        public string Class { get; set; }
    }
