    public static class VisualTreeHelperExtension
    {
        struct StackElement
        {
            public FrameworkElement Element { get; set; }
            public int Position { get; set; }
        }
    public static IEnumerable<T> FindAllVisualDescendantByNameOfType<T>(this FrameworkElement parent, String name) where T : FrameworkElement
    {
        if (parent == null)
            yield break;
        Stack<StackElement> stack = new Stack<StackElement>();
        int i = 0;
        while (true)
        {
            if (i < VisualTreeHelper.GetChildrenCount(parent))
            {
                FrameworkElement child = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (child != null)
                {
                    Display(child, stack.Count);
                    T t = child as T;
                    if (t != null && t.Name == name)
                        yield return t;
                    stack.Push(new StackElement { Element = parent, Position = i });
                    parent = child;
                    i = 0;
                    continue;
                }
                ++i;
            }
            else
            {
                // back at the root of the search
                if (stack.Count == 0)
                    yield break;
                StackElement element = stack.Pop();
                parent = element.Element;
                i = element.Position;
                ++i;
            }
        }
    }
