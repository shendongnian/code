    public virtual int LoadData()
    {
        return 0;
    }
    public async Task<int> LoadDataAsync()
    {
        return await Task.Run(() => LoadData());
    }
