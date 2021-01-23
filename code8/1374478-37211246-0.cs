    public async Task GetDashboardItemsAsync()
    {
        var getUserTask = GetUserListAsync();
        var getNewsTask = GetNewsListAsync();
        var getRecentlyViewedTask = GetRecentlyViewedListAsync();
        var getSentEmailsTask = GetSentEmailsListAsync();
        
        await Task.WhenAll(getUserTask,
                           getNewsTask,
                           getRecentlyViewedTask,
                           getSentEmailsTask);
        return new List<DashboardItem>
        {
            getUserTask.Result,
            getNewsTask.Result,
            getRecentlyViewedTask.Result,
            getSentEmailsTask.Result,
        };
    }
