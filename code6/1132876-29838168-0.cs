    string line;
    while ((line = process.StandardOutput.ReadLine()) != null)
    {
        Console.WriteLine(line);
        if (line.EndsWith("Enter next command: "))
        {
            process.StandardInput.WriteLine("next command");
        }
    }
