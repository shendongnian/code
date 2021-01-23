    static void Main(string[] args)
    {
        string path = @"path where to check";
        Node n = new Node();
        n.Nodes = new List<Node>();
        GetNodes(path, n);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string json = js.Serialize(n);
    }
    public static void GetNodes(string path, Node node)
    {
        if (File.Exists(path))
        {
            node = new Node(path);
        }
        else if (Directory.Exists(path))
        {
            node.Data = "\\";
            GetFiles(path, node);
            
            foreach ( string item in Directory.GetDirectories(path))
            {
                Node n = new Node();
                n.Nodes = new List<Node>();
                n.Data = item;
                GetFiles(path, n);
                node.Nodes.Add(n);
            }
        }
    }
    public static void GetFiles(string path, Node node)
    {
        foreach (string item in Directory.GetFiles(path))
        {
            node.Nodes.Add(new Node(item));
        }
    }
    public class Node
    {
        public Node()
        { }
        public Node(string fileName)
        {
            Nodes = new List<Node>();
            Data = fileName;
        }
        public List<Node> Nodes { get; set; }
        public string Data { get; set; }
    }
