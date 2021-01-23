    decimal price;
    decimal quantity;
    decimal vatRate;
    decimal totalPrice;
    Console.WriteLine("please enter the price of one kilo of tomatoes without VAT.");
    price = Convert.ToDecimal(Console.ReadLine());
            
    Console.WriteLine("Please enter the amount of kilos you want.");
    quantity = Convert.ToDecimal(Console.ReadLine());
            
    Console.WriteLine("Please enter the VAT rate. (Default = 20)");
    decimal input;
    if (Decimal.TryParse(Console.ReadLine(), out input))
    {
        vatRate = input / 100;
    }
    else
    {
        vatRate = 0.20M;
    }
    totalPrice = price * quantity * (1 + vatRate);
    Console.WriteLine("Total price = {0}", totalPrice);
