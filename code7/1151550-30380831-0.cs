    public static IEnumerable<T> PreOrder<T>(
        IEnumerable<T> source,
        Func<T, IEnumerable<T>> childSelector)
    {
        var stack = new Stack<IEnumerator<T>>();
        stack.Push(source.GetEnumerator());
        try
        {
            while (stack.Any())
            {
                var current = stack.Pop();
                if (current.MoveNext())
                {
                    stack.Push(current);
                    var children = childSelector(current.Current);
                    stack.Push(children.GetEnumerator());
                    yield return current.Current;
                }
                else
                {
                    current.Dispose();
                }
            }
        }
        finally
        {
            foreach (var iterator in stack)
                iterator.Dispose();
        }
    }
