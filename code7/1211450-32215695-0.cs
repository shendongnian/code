    public static class RecursiveEnumerableExtensions
    {
        static IEnumerable<T> PushHierarchy<T>(
            T value,
            Func<T, IEnumerable<T>> children,
            List<KeyValuePair<T, IEnumerator<T>>> list)
        {
            list.Add(new KeyValuePair<T, IEnumerator<T>>(value, children(value).GetEnumerator()));
            return list.Select(pair => pair.Key);
        }
        public static IEnumerable<IEnumerable<T>> TraverseHierarchy<T>(
            T root,
            Func<T, IEnumerable<T>> children)
        {
            var list = new List<KeyValuePair<T, IEnumerator<T>>>();
            try
            {
                yield return PushHierarchy(root, children, list);
                while (list.Count != 0)
                {
                    var node = list[list.Count - 1];
                    if (!node.Value.MoveNext())
                    {
                        list.RemoveAt(list.Count - 1);
                        node.Value.Dispose();
                    }
                    else
                    {
                        yield return PushHierarchy(node.Value.Current, children, list);
                    }
                }
            }
            finally
            {
                foreach (var pair in list)
                    pair.Value.Dispose();
            }
        }
    }
