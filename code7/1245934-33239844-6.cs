    private List<T> items = new List<T>();
    public T Item
    {
        get { return items.FirstOrDefault(); }
    }
    public List<T> Items
    {
        get { return items; }
    }
