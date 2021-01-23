    private void doTickets()
        {
            AdultTix:
            Console.Write("Please enter the number of tickets sold for Adult:(100 for exit)");
            int adultTickets = 0;
            while (!int.TryParse(Console.ReadLine(), out adultTickets))
            {
                Console.WriteLine("You may only enter numbers");
                Console.ReadLine();
                if (int.TryParse(Console.ReadLine(), out adultTickets))
                {
                    break;
                }
            }
            if (adultTickets == 100)
            {
                Console.WriteLine("Good Bye");
                Environment.Exit(0);
            }
            if (adultTickets > 0 && (adultTickets < 5 || adultTickets > 30))
            {
                Console.WriteLine("You may only purchase between 5 and 30 adult tickets. You tried to purchase " + adultTickets.ToString() + ". Please try again.");
                goto AdultTix;
            }
            ChildTix:
            Console.Write("Please enter the number of tickets sold for Child:(100 for exit)");
            int childTickets = 0;
            while (!int.TryParse(Console.ReadLine(), out childTickets))
            {
                Console.WriteLine("You may only enter numbers");
                Console.ReadLine();
                if (int.TryParse(Console.ReadLine(), out childTickets))
                {
                    break;
                }
            }
            if (childTickets == 100)
            {
                Console.WriteLine("Good Bye");
                Environment.Exit(0);
            }
            if (childTickets > 0 && (childTickets < 5 || childTickets > 30))
            {
                Console.WriteLine("You may only purchase between 5 and 30 child tickets. You tried to purchase " + childTickets.ToString() + ". Please try again.");
                goto ChildTix;
            }
            int[] arrAmt = new int[] { 30, 20 };
            int[] tickets = new int[] { adultTickets, childTickets };
            int totalCost = 0;
            totalCost += tickets[0] * arrAmt[0];
            Console.Write("The sale amount of tickets for Adult: ${0} \n", (arrAmt[0] * tickets[0]));
            totalCost += tickets[1] * arrAmt[1];
            Console.Write("The sale amount of tickets for child: ${0} \n", (arrAmt[1] * tickets[1]));
            Console.WriteLine("The total sale amount: {0}", totalCost);
        }
