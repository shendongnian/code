    public Stat() { ... }
    public Stat(Stat copyMe)
    {
        this.Name = copyMe.Name;
        this.MinValue = copyMe.MinValue;
        this.MaxValue = copyMe.MaxValue;
        this.CurrentValue = copyMe.CurrentValue;
    }
