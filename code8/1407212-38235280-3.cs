    class Program {
        public static void Main(string[] args) {
            var tree = new Dictionary<MyObject, IEnumerable<MyObject>>();
            Helper.Getter g = t => (int)t.index;
            Helper.Setter s = (t, o) => { t.index = o; };
            var root = new MyObject();
            var node1 = new MyObject();
            var node2 = new MyObject();
            s(root, 1);
            s(node1, 1);
            s(node2, 100);
            tree.Add(root, new[] { node1, node2 });
            Helper.PrintTree(tree, g);
            Helper.UseFunctionOnTree(root, tree,
                (t, g1, s1) => { return Helper.GenericAddOffset(t, g1, s1, (x, y) => x + y, 3); }, g, s);
            Helper.PrintTree(tree, g);
            Console.ReadLine();
        }
    }
