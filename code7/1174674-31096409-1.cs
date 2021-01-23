    protected abstract Task FirstMethodAsync(string var1, string var2);
    protected abstract Task SecondMethodAsync(int var1, int var2);
    public async Task InitializeAsync()
    {
         Console.WriteLine("Start Process ABSMethod1");
         await FirstMethodAsync("var1", "var2");
         Console.WriteLine("End Process ABSMethod1");
         Console.WriteLine("Start Process ABSMethod2");
         await SecondMethodAsync(1, 2);
         Console.WriteLine("End Process ABSMethod2");
    }
