    public async Task<IViewComponentResult> InvokeAsync()
    {
        var itemsTask = GetItemsAsync(maxPriority, isDone);
        // We can do some other work here,
        // while the itemsTask is still running.
        var items = await itemsTask;
        return View(items);
    }
