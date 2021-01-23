    private async void PullToRefreshRequestAsync(object sender, EventArgs e)
    {
        await PopulateListAsync();
    }
    public async Task PopulateListAsync()
    {
        curoListsDal db = new curoListsDal();
        listView.ItemsSource = await db.GetListsAsync();
    }
