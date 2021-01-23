    string row;
    Console.WriteLine("Enter number of rows");
            while (Int32.TryParse(Console.ReadLine(), out row) == false)
            {
                 Console.WriteLine("Please enter a numeric value");
            }
            Console.WriteLine("You selected {0} rows", row);
