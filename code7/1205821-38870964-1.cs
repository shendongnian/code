    public class Row : IRow<string>
    {
        public string TextNode { get; }
        public string Value { get; }
        public Row(string textNode, string userName)
        {
            TextNode = textNode;
            Value = userName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IRow<string>[] rows =
            {
                new Row("/", "Ahmed"),
                new Row("/1/", "Saeed"),
                new Row("/2/", "Amjid"),
                new Row("/1/1/", "Noura"),
                new Row("/2/1/", "Noura01"),
                new Row("/2/2/", "Reem01"),
                new Row("/1/1/1", "Under_noura")
            };
            var tree = TreeNode<string>.Parse(rows);
            PrintTree(tree);
        }
        private static void PrintTree<T>(TreeNode<T> tree, int level = 0)
        {
            string prefix = new string('-', level*2);
            Console.WriteLine("{0}{1}", prefix, tree.Value);
            foreach (var node in tree.Descendants)
            {
                PrintTree(node, level + 1);
            }
        }
    }
