    public List<Node> AncestorsAndSelf
    {
        get
        {
            List<Node> list = new List<Node> { this };
            Node p = Parent;
            while (p != null)
            {
                list.Add(p);
                p = p.Parent;
            }
            return list;
        }
    }
