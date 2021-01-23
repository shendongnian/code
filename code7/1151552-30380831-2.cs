    public static IEnumerable<T> PostOrder<T>(
        IEnumerable<T> source,
        Func<T, IEnumerable<T>> childSelector)
    {
        var stack = new Stack<Tuple<IEnumerator<T>, bool>>();
        stack.Push(Tuple.Create(source.GetEnumerator(), false));
        try
        {
            while (stack.Any())
            {
                var current = stack.Pop();
                if (current.Item2)
                    yield return current.Item1.Current;
                if (current.Item1.MoveNext())
                {
                    stack.Push(Tuple.Create(current.Item1, true));
                    var children = childSelector(current.Item1.Current);
                    stack.Push(Tuple.Create(children.GetEnumerator(), false));
                }
                else
                {
                    current.Item1.Dispose();
                }
            }
        }
        finally
        {
            foreach (var iterator in stack)
                iterator.Item1.Dispose();
        }
    }
