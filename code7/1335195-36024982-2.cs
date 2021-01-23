    public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
    {
        var itemsTask = GetItemsAsync(maxPriority, isDone);
        // do some other stuff
        var items = await itemsTask;
        return View(items);
    }
