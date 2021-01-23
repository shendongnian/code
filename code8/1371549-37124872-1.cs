     static void Main(string[] args)
     {
        if (args.Length == 0)
           return; // return if no file was dragged onto exe
        string text = File.ReadAllText(args[0]);
        text = text.Replace("~", "~\r\n");
        string path = Path.GetDirectoryName(args[0]) 
           + Path.DirectorySeparatorChar 
           + Path.GetFileNameWithoutExtension(args[0]) 
           + "_unwrapped" + Path.GetExtension(args[0]);
        File.WriteAllText(path, text);
    
     }
