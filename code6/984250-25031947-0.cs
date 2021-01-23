    var parents = new Dictionary<Child, Child>();
    
    void SetParent(Child parent)
    {
        foreach (Child c in child.children)
        {
           parents[c] = parent;
           SetParent(c);
        }
    }
