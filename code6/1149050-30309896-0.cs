    public async Task<ActionResult> Foo(...)
    {
        // ...
        var list = await manager.ReadFeed(url);
        // ... maybe do something with the list
        return View(list);
    }
