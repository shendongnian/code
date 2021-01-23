    static int Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        Console.WriteLine(args[0]); // this will print only 'Some' part of argument all string will be in args seperating by space
        Console.WriteLine(args[1]); // this will print "Parameter"
    
        return 1;
    }
