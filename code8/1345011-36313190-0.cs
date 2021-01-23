        static void Main(string[] args)
        {
            BTree btr = new BTree();
            btr.Add(6);
            btr.Add(2);
            btr.Add(3);
            btr.Add(11);
            btr.Add(30);
            btr.Add(9);
            btr.Add(13);
            btr.Add(18);
            btr.Print();
        }
        public class BNode
        {
            public int item;
            public BNode right;
            public BNode left;
            public BNode(int item)
            {
                this.item = item;
            }
            public void PrintPretty(string indent, bool last)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("\\-");
                    indent += "  ";
                }
                else
                {
                    Console.Write("|-");
                    indent += "| ";
                }
                Console.WriteLine(item);
                var children = new List<BNode>();
                if (this.left != null)
                    children.Add(this.left);
                if (this.right != null)
                    children.Add(this.right);
                for (int i = 0; i < children.Count; i++)
                    children[i].PrintPretty(indent, i == children.Count - 1);
            }
        }
        public class BTree
        {
            private BNode _root;
            private int _count;
            private IComparer<int> _comparer = Comparer<int>.Default;
            public BTree()
            {
                _root = null;
                _count = 0;
            }
            public bool Add(int Item)
            {
                if (_root == null)
                {
                    _root = new BNode(Item);
                    _count++;
                    return true;
                }
                else
                {
                    return Add_Sub(_root, Item);
                }
            }
            private bool Add_Sub(BNode Node, int Item)
            {
                if (_comparer.Compare(Node.item, Item) < 0)
                {
                    if (Node.right == null)
                    {
                        Node.right = new BNode(Item);
                        _count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(Node.right, Item);
                    }
                }
                else if (_comparer.Compare(Node.item, Item) > 0)
                {
                    if (Node.left == null)
                    {
                        Node.left = new BNode(Item);
                        _count++;
                        return true;
                    }
                    else
                    {
                        return Add_Sub(Node.left, Item);
                    }
                }
                else
                {
                    return false;
                }
            }
            public void Print()
            {
                _root.PrintPretty("", true);
            }
        }
