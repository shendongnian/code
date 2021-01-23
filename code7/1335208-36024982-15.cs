    public async Task<IViewComponentResult> InvokeAsync()
    {
        var itemsTask = GetItemsAsync(maxPriority, isDone);
        // Do some other stuff
        // before we need to await.
        var items = await itemsTask;
        return View(items);
    }
