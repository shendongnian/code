    public static Node FindClosestCommonAncestor(IEnumerable<Node> selectedNodes)
    {
        IEnumerable<Node> commonAncestors = selectedNodes.First().AncestorsAndSelf;
        foreach (Node n in selectedNodes.Skip(1))
        {
            commonAncestors = commonAncestors.Intersect(n.AncestorsAndSelf);
        }
        return commonAncestors.OrderByDescending(n => n.Depth).FirstOrDefault();
    }
