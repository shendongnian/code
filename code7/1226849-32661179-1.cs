    static void Create(string fileName)
    {
        if(fileName.Length > 0)
        {
            Console.Write("File name: ");
            using (StreamWriter writer = new StreamWriter(fileName, true))
               ;
            Console.WriteLine("File created");
        }
        else
            Console.WriteLine("No filename given");
    }
    
