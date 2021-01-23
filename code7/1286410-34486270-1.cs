    Console.WriteLine("Type a number: ");
    string line = Console.ReadLine();
    if (!int.TryParse(line, out num)) {
        Console.WriteLine("{0} is not an integer", line);
    }
