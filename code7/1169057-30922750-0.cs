            for (int x = 0; x < section.Length; ++x)
            {
                    if (sectionChoice == section[x])
                    {
                        isValidSection = true;
                        ticketPrice = price[x];
                        totalCost = CalcTicketCost(ticketPrice, ticketQuantity);
                        Console.Write("\n\nTotal cost for the tickets are: {0:c2}", totalCost);
                        break;  // THIS IS THE IMPORTANT CHANGE
                    }
                    else
                        Console.Write("\n\nInvalid entry, {0} does not exsist", sectionChoice);
            }
