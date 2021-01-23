    public IEnumerable<T> GetChildControlsRecursive<T>(Control root) where T: Control
    {
        if (root == null) throw new ArgumentNullException("root");
        List<T> children = new List<T>();
        var stack = new Stack<Control>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            Control item = stack.Pop();
            foreach (Control child in item.Controls)
            {
                if (child is T)
                    children.Add((T) child);
                stack.Push(child);
            }
        }
        return children;
    }
