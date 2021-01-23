        var input = Console.ReadLine();
        if(input == "UneedPassMate")
        {
            System.Diagnostics.Process.Start("chrome.exe");
            System.Environment.Exit(0);
        }
        if (input.ToLower() == "help")
        {
            Console.WriteLine("To Open Chrome\n You Will Need To Enter A Password>");
            Console.ReadLine();
        }
