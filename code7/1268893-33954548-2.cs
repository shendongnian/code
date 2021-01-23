    // parent:
    public virtual Task<int> LoadData()
    {
        return Task.FromResult(0);
    }
    
    // child
    public override async Task<int> LoadData()
    {
        await Task.Delay(200)
        return 1;
    }
