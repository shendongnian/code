    var parents = new Dictionary<Child, Child>();
    
    void SetParent(Child parent)
    {
        foreach (Child c in parent.children)
        {
           parents[c] = parent;
           SetParent(c);
        }
    }
