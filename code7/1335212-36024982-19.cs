    public async Task<IViewComponentResult> InvokeAsync()
    {
        var items = await GetItemsAsync();
        return View(items);
    }
