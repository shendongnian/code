    double price;
    int region;
    Console.Write("Enter the total price of items : ");
    double.TryParse(Console.ReadLine(), out price);
    Console.WriteLine("Select the your region.");
    Console.WriteLine("1 : Pakistan");
    Console.WriteLine("2 : UK");
    Console.WriteLine("3 : Cortia");
    int.TryParse(Console.ReadLine(), out region);
