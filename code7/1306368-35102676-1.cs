    public void AddObjects(params object[] objects)
    {
        foreach (object obj in objects)
        {
            children.AddLast(new Node(obj));
        }
    }
    public void AddChildNodes(params Node[] nodes)
    {
        foreach (Node node in nodes)
        {
            children.AddLast(node);
        }
    }
