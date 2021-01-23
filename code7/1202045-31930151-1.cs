    void main()
    {
        string silent = "false"; // silent is declared here in outer scope so it can be used in the second if()
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("RSA #: ");
        string LineIN = Console.ReadLine();
        if (LineIN == "silent")
        {
            silent = "true";
        }
        if (silent == "true")
        {
            // do something
        }
    }
