    private string NextUrl { get; set; }
    private int currentPage;
    private object MyData { get; set; }
    private bool _isLoading = false;
    public bool isLoading
    {
        get { return _isLoading; }
        set { _isLoading = value; }
    }
    public bool HasMoreItems
    {
        get
        {
            return hasMoreItems;
        }
    }
    private async Task<LoadMoreItemsResult> LoadDataAsync()
    {
        if (!isLoading)
            isLoading = true;
        else
            return new LoadMoreItemsResult { Count = (uint)this.Count };
        var result = await this.Source.GetPage(this.MyData, this.NextUrl, this.CurrentPage++);
        if (string.IsNullOrEmpty(result.NextUrl))
            hasMoreItems = false;
        else
            hasMoreItems = true;
        if (result != null || result.Items.Count() == 0)
        {
            this.NextUrl = result.NextUrl;
            resultCount = (uint)result.Items.Count();
            await dispatcher.RunAsync(
                CoreDispatcherPriority.Normal,
                () =>
                {
                    foreach (ItemType item in result.Items)
                        this.Add(item);
                });
        }
        isLoading = false;
        return new LoadMoreItemsResult { Count = (uint)this.resultCount }; ;
    }
    public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count = 0)
    {
        return LoadDataAsync().AsAsyncOperation<LoadMoreItemsResult>();
    }
