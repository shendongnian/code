    public static int SetDecendents(Node n)
    {
        if (n.Children.Count() == 0)
        {
            n.Decendents = 1;
        }
        else
        {
            n.Decendents = n.Children.Count() + n.Children.Sum(c => SetDecendents(c));
        }
		
        return n.Decendents;
    }
