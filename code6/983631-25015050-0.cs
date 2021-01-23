    public class Entry
    {
        public Entry(int id, int lvl, int sublvl)
        {
            UniquePartID = id;
            Level = lvl;
            SubLevel = sublvl;
        }
        public int UniquePartID;
        public int Level;
        public int SubLevel;
    }
    public class Node
    {
        public int UniquePartID;
        public Node Parent = null;
        public List<Node> Children = new List<Node>();
    }
    public List<Node> LastLayerNodes = new List<Node>();
    public Node BuildHierarchy(List<Entry> entries)
    {
        Node root = null;
        foreach (Entry entry in entries)
        {
            Node node = new Node();
            node.UniquePartID = entry.UniquePartID;
            if (entry.Level == 0)
            {
                root = node;
                LastLayerNodes.Add(root);
            }
            else
            {
                node.Parent = LastLayerNodes[entry.Level - 1];
                node.Parent.Children.Add(node);
                if (LastLayerNodes.Count <= entry.Level)
                    LastLayerNodes.Add(node);
                else
                    LastLayerNodes[entry.Level] = node;
            }
        }
        return root;
    }
