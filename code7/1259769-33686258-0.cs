    found = false;
    double priceFound = 0;
    for (int i = 0; i < 5; i++)
    {
        if (order.Equals(toppings[i]))
        {
            found = true;
            priceFound = price[i]; // store the found price
        }
    }
    Console.WriteLine("The price of " + order + " is $" + priceFound);
