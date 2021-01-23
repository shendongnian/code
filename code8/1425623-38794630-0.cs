    private object _timerLock = new object();
    private void timer1_Tick(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Acquiring Lock");
        if (!Monitor.TryEnter(_timerLock))
        {
            Console.WriteLine("Lock Denied");
            return;
        }
        try
        { 
            Console.WriteLine("Lock Acquired");
            //retrieve data from database
            //read rows
            //Loop through rows
            //send values through network
            //receive response and update db
            Monitor.Exit(_timerLock);
        }
        catch (Exception ex)
        {
            Library.WriteErrorLog(ex);
        }
    }
