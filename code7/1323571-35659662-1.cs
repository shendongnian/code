    public static void SearchDetails()
    {
    Console.WriteLine("Enter ID Number");
    
    string myfile = System.IO.File.ReadAllLines(@"C:\\file.txt")[linenumber];
    System.Console.WriteLine(myfile);
    }
