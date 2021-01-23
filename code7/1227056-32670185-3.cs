    public static int SetDecendents(Node n)
    {
        n.Decendents = 1 + n.Children.Sum(c => SetDecendents(c));
        return n.Decendents;
    }
