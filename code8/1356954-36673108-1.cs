    double? priceInputVal = null;
    do
    {
        Console.Write("Input the price of the beverage : ");
        priceInputVal = ValidateBrand(Console.ReadLine());
        if (priceInputVal == null)
        {
            Console.WriteLine("Please, write a valid number");
        }
    }
    while (princeInputVal == null)
    
