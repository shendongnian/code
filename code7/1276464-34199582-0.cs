    var reader = new StreamReader("randomTextFile.txt");
    var line = reader.ReadLine();
    while (line != null)
    {
        Console.WriteLine(line);
        line = reader.ReadLine();
    }
    reader.Close();
    Console.ReadLine();
