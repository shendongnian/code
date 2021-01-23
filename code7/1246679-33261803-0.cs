    foreach (string  line in System.IO.File.ReadAllLines(FILEPATH))
    {
        if(line.Contains(toSearch))
            Console.WriteLine(line);
    }
