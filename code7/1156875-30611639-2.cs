    static void Main(string[] args)
    {
        var thread = new Thread(ShowMediaWindow);
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
            
        while (true) // Just to test console working
        {
            Console.Write("\r" + DateTime.Now);
            Thread.Sleep(100);
        }
    }
    static void ShowMediaWindow()
    {
        new MediaWindow().ShowDialog();
    }
