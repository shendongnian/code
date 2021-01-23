    public interface IRow<out T>
    {
        string TextNode { get; }
        T Value { get; }
    }
    public class TreeNode<T>
    {
        private struct NodeDescriptor
        {
            public int Level { get; }
            public int ParentIndex { get; }
            public NodeDescriptor(IRow<T> row)
            {
                var split = row.TextNode.Split(new [] {"/"}, StringSplitOptions.RemoveEmptyEntries);
                Level = split.Length;
                ParentIndex = split.Length > 1 ? int.Parse(split[split.Length - 2]) - 1 : 0;
            }
        }
        public T Value { get; }
        public List<TreeNode<T>> Descendants { get; }
        private TreeNode(T value)
        {
            Value = value;
            Descendants = new List<TreeNode<T>>();
        }
        public static TreeNode<T> Parse(IReadOnlyList<IRow<T>> rows)
        {
            if (rows.Count == 0)
                return null;
            var result = new TreeNode<T>(rows[0].Value);
            FillParents(new[] {result}, rows, 1, 1);
            return result;
        }
        private static void FillParents(IList<TreeNode<T>> parents, IReadOnlyList<IRow<T>> rows, int index, int currentLevel)
        {
            var result = new List<TreeNode<T>>();
            for (int i = index; i < rows.Count; i++)
            {
                var descriptor = new NodeDescriptor(rows[i]);
                if (descriptor.Level != currentLevel)
                {
                    FillParents(result, rows, i, descriptor.Level);
                    return;
                }
                var treeNode = new TreeNode<T>(rows[i].Value);
                parents[descriptor.ParentIndex].Descendants.Add(treeNode);
                result.Add(treeNode);
            }
        }
    }
