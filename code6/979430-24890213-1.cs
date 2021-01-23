    double price;
    if (PRICES.TryGetValue(20, out price)) {
        Console.WriteLine("The price is {0}", price);
    } else {
        Console.WriteLine("Sorry, no price found!");
    }
