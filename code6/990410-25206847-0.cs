    public class GraphSerializer 
    {
        Dictionary<string, Node> parsedNodes;
        public void MarkNodeAsParsed(Node node)
        {
            parsedNodes.Add(node.Id, node);
        }
        public bool IsNodeParsed(string id)
        {
            return parsedNodes.ContainsKey(id);
        }
        public Node GetNode(string id)
        {
            return parsedNodes[id];
        }
        [...]
    }
