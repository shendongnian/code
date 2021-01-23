    public static void Main(string[] args)
    {
        if (args.Length <= 0)
        {
            Console.WriteLine("\nYou need to include a filename.");
        }
        else
        {
           StreamReader InFile = null;
           StreamWriter OutFile = null;
    
           try
           {
               InFile = File.OpenText(args[0]);
               OutFile = File.CreateText("OutFile.txt");
               Console.Write("\nNumbering...");
           ...
           }
           catch ... 
           {
           }
        // InFile and OutFile still known here !
        }
     // InFile and OutFile are unknown here !
       
