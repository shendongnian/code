    string[] lines = File.ReadAllLines(myFile)
    // Get the last three lines
    int count = 0;
    for (int i = lines.length - 1; i >= 0; i++)
    {
        Console.WriteLine(lines[i]);
        count++;
        if (count == 3) 
        {
            break;
        }
    }
