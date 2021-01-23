    static void Main(string[] args)
    {
        Queue<string> lines = new Queue<string>();
        using (var reader = new StreamReader(args[0]))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("error"))
                {
                    Console.WriteLine("----- ERROR -----");
                    foreach (var errLine in lines)
                        Console.WriteLine(errLine);
                    Console.WriteLine(line);
                    Console.WriteLine("-----------------");
                }
                
                lines.Enqueue(line);
                while (lines.Count > 6)
                    lines.Dequeue();
            }
        }
    }
