    public class NodeList
    {
        public int Head { get; }
        public NodeList Tail { get; set; }
        public NodeList(int head, NodeList tail)
        {
            Head = head;
            Tail = tail;
        }
        private NodeList Add(int value, NodeList current)
        {
            var nextNode = current.Tail;
            if (nextNode == null)
            {
                current.Tail = new NodeList(value, null);
                return current.Tail;
            }
            if (nextNode.Head > value)
            {
                current.Tail = new NodeList(value, nextNode);
                return current.Tail;
            }
            // Recursive
            return Add(value, nextNode);
        }
        public NodeList Add(int value)
        {
            return Add(value, this);
        }
    }
