    using System.Collections.Generic;
    using System.Linq;
    
    namespace JsonSerializableNode
    {
        public class Node
        {
            private Node() { } // used for deserializing
    
            public Node(string name, Node parent) // used everywhere else in your code
            {
                Name = name;
                Parent = parent;
            }
    
            public string Name { get; }
    
            private Node Parent { get; set; }
    
            public Node GetParent()
            {
                return Parent;
            }
    
            public List<Node> Children
            {
                get
                {
                    return ChildrenDict.Values.ToList();
                }
    
                set
                {
                    ChildrenDict.Clear();
                    if (value != null && value.Count > 0)
                        foreach (Node child in value)
                            Add(child);
                }
            }
    
            // One could use a typed OrderedDictionary here, since Json lists guarantee the order of the children:
            private Dictionary<string, Node> ChildrenDict { get; } = new Dictionary<string, Node>();
            
            public Node Add(Node child)
            {
                ChildrenDict.Add(child.Name, child);
                child.Parent = this;
                return child;
            }
    
            public Node Get(string name)
            {
                return ChildrenDict[name];
            }
    
            public bool Remove(string name)
            {
                return ChildrenDict.Remove(name);
            }
        }
    }
