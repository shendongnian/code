    static void Main(string[] args)
    {
        //input
        Vehicle v1 = new Vehicle();
        Console.Write("Enter the make of 1st vehicle: ");
        v1.Make = Console.ReadLine();
        Console.Write("Enter the model of 1st vehicle: ");
        v1.Model = Console.ReadLine();
        Console.WriteLine("Enter the year of manufacturing for 1st vehicle:");
        v1.Year = int.Parse(Console.ReadLine());
        //output
        Console.WriteLine("The data for 1st vehicle: ");
        Console.WriteLine(v1);
        ...
    }
