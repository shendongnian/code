    static void Main()
    {
       var timer = new System.Threading.Timer(RunDelayed, null, imeSpan.FromSeconds(5).TotalMilliseconds, Timeout.Infinite );
    }
    private void Callback( Object state )
    {
        // do the work.. (be careful, this is running on a background thread)
        Console.WriteLine("Timer ticked...");
        Console.ReadLine(); 
    }
