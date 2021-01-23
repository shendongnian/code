    Console.Write("Write an interger between 1 and 100:");
    string inputS = Console.ReadLine();
    int inputI;
    if (int.TryParse(inputS, out inputI) && inputI < 100)
    {
        var lineBuilder = new StringBuilder();
        while (inputI <= 100)
        {
            var numStr = inputI + " ";
            if (lineBuilder.Length + numStr.Length > Console.WindowWidth)
            {
                Console.WriteLine(lineBuilder.ToString());
                lineBuilder.Clear();
            }
            lineBuilder.Append(numStr);
            inputI++;
        }
        if (lineBuilder.Length > 0)
        {
            Console.WriteLine(lineBuilder.ToString());
        }
        Console.ReadKey();
    }
