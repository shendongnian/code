    string[] lines = File.ReadAllLines(myFile)
    // Get the last three lines
    Console.WriteLines(lines[lines.Length - 3]);
    Console.WriteLines(lines[lines.Length - 2]);
    Console.WriteLines(lines[lines.Length - 1]);
