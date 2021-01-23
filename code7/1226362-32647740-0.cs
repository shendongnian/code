    public Node Copy(Node origin, Node parent = null)
    {
        if (origin == null)
        {
            return null;
        }
        var result = new Node { Parent = parent, Name = origin.Name };
        result.Children = origin.Children != null ? origin.Children.Select(x => Copy(x, result)).ToList() : null;
        return result;
    }
