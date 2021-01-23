    // parent:
    public virtual int LoadData()
    {
        return 0;
    }
    public virtual Task<int> LoadDataAsync()
    {
        return Task.Run(() => LoadData());
        // or implement it awaitable; whatever you need, there is no difference.
    }
    
    // child
    public override int LoadData()
    {
        return 0;
    }
    public override async Task<int> LoadDataAsync()
    {
        await Task.Delay(200); // or don't await it; just return the Task. whatever is your requirement.
        return 1;
    }
