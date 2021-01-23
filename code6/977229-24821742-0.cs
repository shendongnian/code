        internal static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
        {
            foreach (var node in c.OfType<TreeNode>())
            {
                yield return node;
                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }
        public static IEnumerable<T> Ancestors<T>(this T o, Func<T, T> action)
        {
            while (o != null)
            {
                yield return o;
                o = action(o);
            }
        }
