    static void Main()
    {
        using (var stream = File.OpenRead(@"C:\Temp\Foldertest\SomeTextFile.txt"))
        {
            Application.Run(new Form1());
        }
    }
   
