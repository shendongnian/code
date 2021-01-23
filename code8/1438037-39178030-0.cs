     public void calculate_Tickets()
        {
            int adult = adult_Tickets();
            int child = child_Tickets();
            ticket_Prices(adult, child);
        }
        private int adult_Tickets()
        {
            Console.Write("Please enter the number of tickets sold for Adult:(100 for exit)");
            int adultTickets = 0;
            if (int.TryParse(Console.ReadLine(),out adultTickets)){
                if (adultTickets == 100)
                {
                    Console.WriteLine("Good Bye");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("you may only inter numbers");
                    adult_Tickets();
                }
                
            }
            return adultTickets;
        }
        private int child_Tickets() {
            Console.Write("Please enter the number of tickets sold for child:(100 for exit)");
            int childTickets = 0;
            if (int.TryParse((Console.ReadLine(), out childTickets)){
                if (childTickets == 100)
                {
                    Console.WriteLine("Good Bye");
                    Environment.Exit(0);
                }
            } else
            {
                Console.WriteLine("you may only inter numbers");
                child_Tickets();
            }
            return childTickets;
        }
        private void ticket_Prices(int adultTickets, int childTickets) {
            int[] arrAmt = new int[] { 30, 20 };
            int[] tickets = new int[] { adultTickets, childTickets };
            int totalCost = 0;
            if (tickets[0] >= 5 && tickets[0] <= 30)
            {
                totalCost += tickets[0] * arrAmt[0];
                Console.Write("The sale amount of tickets for Adult: ${0} \n", (arrAmt[0] * tickets[0]));
            }
            else
            {
                Console.Write("Not Valid \n");
            }
            if (tickets[1] >= 5 && tickets[1] <= 30)
            {
                totalCost += tickets[1] * arrAmt[1];
                Console.Write("The sale amount of tickets for child: ${0} \n", (arrAmt[1] * tickets[1]));
            }
            Console.WriteLine("The total sale amount: {0}", totalCost);
        }
