    public async Task<string> GetItemsAsync()
    {
        var a = Task1();
        var b = Task2();
        var c = Task3();
        return string.Concat(await Task.WhenAll(a, b, c));
    }
