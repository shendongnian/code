    string input = Console.In.ReadLine();
    int number = -1;
    int.TryParse(input, out number);
    switch (number)
    {
        case 1:
            Console.Out.WriteLine("January");
            break;
        case 2:
            Console.Out.WriteLine("February");
            break;
        case -1:
            Console.Out.WriteLine("Please input a valid number");
            break;
        default:
            Console.Out.WriteLine("There are only 12 months in a year");
            break;
    }
