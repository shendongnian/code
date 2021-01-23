    async Task<ItemData> GetItemAsync(Item item)
    {
        while (true)
        {
            if (await isSearchFinishedAsync(item))
                break;
            await Task.Delay(30 * 1000);
        }
        return await DownloadDataAsync(item);
    }
    // ...
    var items = getItems();
    var tasks = items.Select(i => GetItemAsync(i)).ToString();
    await Task.WhenAll(tasks);
    var data = tasks.Select(t = > t.Result);
