    static void Main(string[] args)
    {
        string text = System.IO.File.ReadAllText(@"C:\test.cpp");
        text = text.Replace('/', ' ');
        text = text.Replace('*', ' ');
        //Do all possible cleaning of text: text.Trim() etc...
            
        //Put text into text box (for now just display into console)
        Console.WriteLine(text);
        Console.ReadLine();
    }
