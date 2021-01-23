    public static void SearchDetails()
    {
    Console.WriteLine("Enter ID Number");
        int linenumber = 0;
    int.TryParse(Console.ReadLine(), out linenumber);
    string myfile = System.IO.File.ReadAllLines(@"C:\\file.txt")[linenumber];
    System.Console.WriteLine(myfile);
    }
