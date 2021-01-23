    static void Main(string[] args)
    {
        // Double clicked on executable file
        if (args == null || string.IsNullOrEmpty(args[0]))
        {
            Application.Run(new Form1());
        }
        // Launched from Windows startup
        else if (args[0] == "startup")
        {
            Application.Run(new Form2());
        }
        // Unrecognized startup parameter
        else
            throw new ArgumentOutOfRangeException(...);
    }
