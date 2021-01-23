    int RealID = 100;
    Console.WriteLine("Enter Number");
    int ID = int.Parse(Console.ReadLine());
    while( ID != ReadID)
    {
        Console.WriteLine("Incorrect ID. Enter another number");
        ID = int.Parse(Console.ReadLine());
    }
    Console.WriteLine("You entered the correct ID");
