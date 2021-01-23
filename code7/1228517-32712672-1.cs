    public static IEnumerable<XElement> ElementsAtDepth(this XNode node, int depth)
    {
        return node.Elements().ElementsAtDepth(depth - 1);
    }
    public static IEnumerable<XElement> ElementsAtDepth(
        this IEnumerable<XElement> elements, int depth)
    {
        // TODO: Validate that depth >= 0
        return depth == 0 ? elements : elements.Elements().ElementsAtDepth(depth - 1);
    }
