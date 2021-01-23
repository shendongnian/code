    private List<T> items = new List<T>();
    public T Item
    {
        get{return Items.FirstOrDefault();}
    }
    public List<T> Items
    {
        get{return items;}
    }
