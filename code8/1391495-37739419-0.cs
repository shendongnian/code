    public static void Main()
    {
        var timer = new Timer();
        timer.Elapsed+= OnTimedEvent;
        timer.Interval=5000;
        timer.Enabled=true;
        Console.ReadKey();
    }
    
     private static void OnTimedEvent(object source, ElapsedEventArgs e)
     {
         Button_Click(null, null);
     }
