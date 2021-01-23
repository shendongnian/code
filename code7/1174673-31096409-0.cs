    protected abstract Task ABSMethod1Async(String var1, String var2);
    protected abstract Task ABSMethod2Async (int var1, int var2);
    public async Task InitializeAsync()
    {
         Console.WriteLine("Start Process ABSMethod1");
         await ABSMethod1("var1", "var2");
         Console.WriteLine("End Process ABSMethod1");
         Console.WriteLine("Start Process ABSMethod2");
         await ABSMethod2(1, 2);
         Console.WriteLine("End Process ABSMethod2");
    }
 
