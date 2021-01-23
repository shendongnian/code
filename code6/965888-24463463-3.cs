    async Task<ItemData> ProcessItemAsync(Item item)
    {
        while (true)
        {
            if (await isSearchFinishedAsync(item))
                break;
            await Task.Delay(30 * 1000);
        }
        return await downloadDataAsync(item);
    }
    // ...
    var items = getItems();
    var tasks = items.Select(i => ProcessItemAsync(i)).ToArray();
    await Task.WhenAll(tasks);
    var data = tasks.Select(t = > t.Result);
