    List<int> ListOfIds;
    public static void SomeFunction()
    {
        // Populate the list of ids here
        aTimer = new System.Timers.Timer(2000);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.Enabled = true;
        Console.WriteLine("Press the Enter key to exit the program... ");
        Console.ReadLine();
        Console.WriteLine("Terminating the application...");
    }
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        deleteItem(ListOfIds[0]);
        ListOfIds.RemoveAt(0);
    }
