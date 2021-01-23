    Console.WriteLine("Type Help If You Need More Info:");
    string input = Console.ReadLine();
    if(input == "UneedPassMate")
    {
        System.Diagnostics.Process.Start("chrome.exe");
        System.Environment.Exit(0);
    }
    if (input == "Help" || input == "help")
    {
        Console.WriteLine("To Open Chrome\n You Will Need To Enter A Password>");
        Console.ReadLine();
    }        
