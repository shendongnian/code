    class Node
        {
            IList<Node> Nodes { get; set; }
            internal string Serialize(IComparer<Node> comparer)
            {
                Nodes = (IList<Node>)Nodes.OrderBy(c => c, comparer);
                return JsonConvert.SerializeObject(Nodes, Formatting.Indented, new JsonSerializerSettings() { });
            }
        }
        class SortHelper : IComparer<Node>
        {
            int IComparer<Node>.Compare(Node x, Node y)
            {
                // compare object x and y by custom logic
                return 0;
            }
        }
