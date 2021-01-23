    public static class VisualTreeHelperExtension
    {
        struct StackElement
        {
            public FrameworkElement Element { get; set; }
            public int Position { get; set; }
        }
        public static IEnumerable<FrameworkElement> FindAllVisualDescendants(this FrameworkElement parent)
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
                        if (child != null)
                            yield return child;
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
    }
