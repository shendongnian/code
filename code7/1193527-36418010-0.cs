    /// <summary>
    /// Parser extension methods
    /// </summary>
    public static class ParserExt
    {
        /// <summary>
        /// Converts parser nodes tree to flat collection
        /// </summary>
        /// <param name="item"></param>
        /// <param name="childSelector"></param>
        /// <returns></returns>
        public static IEnumerable<ParseTreeNode> Traverse(this ParseTreeNode item, Func<ParseTreeNode, IEnumerable<ParseTreeNode>> childSelector)
        {
            var stack = new Stack<ParseTreeNode>();
            stack.Push(item);
            while (stack.Any())
            {
                var next = stack.Pop();
                yield return next;
                var childs = childSelector(next).ToList();
                for (var childId = childs.Count - 1; childId >= 0; childId--)
                {
                    stack.Push(childs[childId]);
                }
            }
        }
    }
