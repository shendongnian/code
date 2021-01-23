    public static class StepExtensions
    {
        public static IEnumerable<Step> TraverseSteps(this Steps root)
        {
            if (root == null)
                throw new ArgumentNullException();
            return RecursiveEnumerableExtensions.Traverse(root.StepList, s => s.StepList);
        }
        public static IEnumerable<Step> TraverseSteps(this Step root)
        {
            if (root == null)
                throw new ArgumentNullException();
            return RecursiveEnumerableExtensions.Traverse(root, s => s.StepList);
        }
        public static bool TryAdd(this Steps root, Step step, string parentId)
        {
            foreach (var item in root.TraverseSteps())
                if (item != null && item.Id == parentId)
                {
                    item.StepList.Add(step);
                    return true;
                }
            return false;
        }
        public static void Add(this Steps root, Step step, string parentId)
        {
            if (!root.TryAdd(step, parentId))
                throw new InvalidOperationException(string.Format("Parent {0} not found", parentId));
        }
    }
    public static class RecursiveEnumerableExtensions
    {
        // sort of adapted from https://stackoverflow.com/questions/10253161/efficient-graph-traversal-with-linq-eliminating-recursion        
        public static IEnumerable<T> Traverse<T>(
            T root,
            Func<T, IEnumerable<T>> children)
        {
            yield return root;
            var stack = new Stack<IEnumerator<T>>();
            try
            {
                stack.Push(children(root).GetEnumerator());
                while (stack.Count != 0)
                {
                    var enumerator = stack.Peek();
                    if (!enumerator.MoveNext())
                    {
                        stack.Pop();
                        enumerator.Dispose();
                    }
                    else
                    {
                        yield return enumerator.Current;
                        stack.Push(children(enumerator.Current).GetEnumerator());
                    }
                }
            }
            finally
            {
                foreach (var enumerator in stack)
                    enumerator.Dispose();
            }
        }
        public static IEnumerable<T> Traverse<T>(
            IEnumerable<T> roots,
            Func<T, IEnumerable<T>> children)
        {
            return from root in roots
                   from item in Traverse(root, children)
                   select item;
        }
    }
