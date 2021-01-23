    public static IEnumerable<T> GetChildControlsRecursive<T>(this Control root) where T: Control
    {
        if (root == null) throw new ArgumentNullException("root");
        var stack = new Stack<Control>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            Control parent = stack.Pop();
            foreach (Control child in parent.Controls)
            {
                if (child is T)
                    yield return (T) child;
                stack.Push(child);
            }
        }
        yield break;
    }
