    using (StreamReader sr = new StreamReader(file.FullName))
    {
        string line;
        while((line = sr.ReadLine()) != null)
        { 
            if (line.Contains(sTerm))
            {
                Console.WriteLine("{0} contains\"{1}\"", file.Name, sTerm);
                break;
            }
        }
    }
