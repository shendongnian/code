    static void Main(string[] args)
    {
         Program p = new Program();
         p.MakeAsync().Wait();
    }
    public async Task MakeAsync()
    {
        Console.WriteLine("I'm about to call");
        CallMe c = new CallMe();
        bool x = await c.CallBingMapsAsync(49931);
        Console.WriteLine("I called and the result was {0}", x);
    }
