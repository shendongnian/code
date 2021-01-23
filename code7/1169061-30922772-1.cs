    Dictionary<string, decimal> ticketsPrices = new Dictionary<string, decimal>()
    {
        {"orchestra", 125.25m},
        //...
    };
    bool isValidSection = false;
    string sectionChoice = GetSection();
    int ticketQuantity = GetQuantity();
    if (ticketsPrices.ContainsKey(sectionChoice))
    {
        isValidSection = true;
        decimal ticketPrice = ticketsPrices[sectionChoice];
        decimal totalCost = CalcTicketCost(ticketPrice, ticketQuantity);
        Console.Write("\n\nTotal cost for the tickets are: {0:c2}", totalCost);
    }
    else
        Console.Write("\n\nInvalid entry, {0} does not exsist", sectionChoice);
