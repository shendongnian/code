    public void Add(params Node[] objects)
    {
        foreach (Node obj in objects)
        {
            children.AddLast(obj);
        }
    }
