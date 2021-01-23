    public ConcurrentQueue<int> Items {get;set;}
    [ProtoMember(n)]
    private int[] Items
    {
        get { return Items.ToArray(); }
        set { Items = new ConcurrentQueue<int>(value); }
    }
