    private async Task ProcessAllItemsAsync(List<Item> items)
    {
        foreach (var item in items)
        {
           var response = await Processor.IOBoundTaskAsync(item);
           // Some further processing on the response object.
        }
    }
