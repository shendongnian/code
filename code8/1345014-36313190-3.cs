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
        public enum NodePosition
        {
            left,
            right,
            center
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
            private void PrintValue(string value, NodePosition nodePostion)
            {
                switch (nodePostion)
                {
                    case NodePosition.left:
                        PrintLeftValue(value);
                        break;
                    case NodePosition.right:
                        PrintRightValue(value);
                        break;
                    case NodePosition.center:
                        Console.WriteLine(value);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            private void PrintLeftValue(string value)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("L:");
                Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(value);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            private void PrintRightValue(string value)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("R:");
                Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(value);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            public void PrintPretty(string indent, NodePosition nodePosition, bool last, bool empty)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("└─");
                    indent += "  ";
                }
                else
                {
                    Console.Write("├─");
                    indent += "| ";
                }
                var stringValue = empty ? "-" : item.ToString();
                PrintValue(stringValue, nodePosition);
                if(!empty && (this.left != null || this.right != null))
                {
                    if (this.left != null)
                        this.left.PrintPretty(indent, NodePosition.left, false, false);
                    else
                        PrintPretty(indent, NodePosition.left, false, true);
                    if (this.right != null)
                        this.right.PrintPretty(indent, NodePosition.right, true, false);
                    else
                        PrintPretty(indent, NodePosition.right, true, true);
                }
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
                _root.PrintPretty("", NodePosition.center, true, false);
            }
        }
