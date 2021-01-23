    Console.WriteLine("Type a number: ");
    string line = Console.ReadLine();
        try {
            num = Int32.Parse(line);
        } 
        catch (FormatException) {
            Console.WriteLine("{0} is not an integer", line);
        }
