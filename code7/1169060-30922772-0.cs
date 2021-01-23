    if (section.Contains(sectionChoice))
    {
        isValidSection = true;
        ticketPrice = price[x];
    
        totalCost = CalcTicketCost(ticketPrice, ticketQuantity);
        Console.Write("\n\nTotal cost for the tickets are: {0:c2}", totalCost);
    }
    else
        Console.Write("\n\nInvalid entry, {0} does not exsist", sectionChoice);
