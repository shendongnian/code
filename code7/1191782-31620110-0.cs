    public bool NodeOrChildrenMatch(Node n)
    {
        if (IsMatch(n))
        {
            Show(n);
            return true;
        }
        else
        {
            if (n.Children.Any(NodeOrChildrenMatch))
            {
                Show(n);
                return true;
            }
            return false;
        }
    }
