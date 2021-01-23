     static void Main(string[] args)
     {
        if (args.Length == 0)
           return; // return if no file was dragged onto exe
        string text = File.ReadAllText(args[0]);
        text = text.Replace("~", "~\r\n");
        File.WriteAllText("test.txt", text);
    
     }
