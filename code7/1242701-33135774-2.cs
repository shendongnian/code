    public class PathClass
    {
        private readonly Dictionary<string, int> m_Dictionary;
        public PathClass()
        {
            m_Dictionary = new Dictionary<string, int>();
        }
        public Dictionary<string, int> Dictionary
        {
            get { return m_Dictionary; }
        }
        public void Add(string path, int number)
        {
            if (m_Dictionary.ContainsKey(path))
                MoveOne(path);
            
            m_Dictionary.Add(path, number);
        }
        public void MoveOne(string path)
        {
            int number = m_Dictionary[path];
            m_Dictionary.Remove(path);
            NodePath node_path = new NodePath(path);
            node_path.Last().Index++;
            string moved_node_path = node_path.ConvertToStringFormat();
            if (m_Dictionary.ContainsKey(moved_node_path))
                MoveOne(moved_node_path);
            m_Dictionary.Add(moved_node_path, number);
        }
        
    }
