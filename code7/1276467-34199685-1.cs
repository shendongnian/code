    string line;
    using (var reader = new StreamReader("randomTextFile.txt"))
    {
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
