    public async Task MyMethod()
    {
        var h = new HelloWorld() { Name = "A" };
        await Task.Factory.StartNew(() => { Console.WriteLine(h.Name); });
        h = new HelloWorld() { Name = "B" };
    }
