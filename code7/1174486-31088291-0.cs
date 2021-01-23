    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    
        using (StreamReader reader = new StreamReader("test1.txt",System.Text.Encoding.UTF8))
        {
            string line;
    
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
    
        }
    
        Console.ReadLine();
    }
