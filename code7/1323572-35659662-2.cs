    public static void SearchDetails()
    {
    Console.WriteLine("Enter ID Number");
    int linenumber = 0;
    int.TryParse(Console.ReadLine(), out linenumber);
    string[] lines = System.IO.File.ReadAllLines(@"C:\\file.txt");
    System.Console.WriteLine(lines[linenumber]);
    }
