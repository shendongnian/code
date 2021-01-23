    static void Main(string[] args)
    {
        Console.Write("Voer de prijs van de ticket in: ");
        int priceTicket = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Eent ticket kost €{0},-\n\n", priceTicket);
        Console.Write("Voer in hoeveel tickets u wilt (per 10 1 gratis): ");
        int amountTickets = Convert.ToInt32(Console.ReadLine());
        int ticketsTotalPrice = 0; //amountTickets * priceTicket;
        //if(ticketsTotalPrice % 11 == 0) 
        //{
        //    ticketsTotalPrice -= priceTicket;
        //}
        for(int i = 1; i <= amountTickets; i++)
        {
            if(i % 11 != 0)
            {
                ticketsTotalPrice += priceTicket;
            }
        }
        string ticketsTotalPriceStr = ticketsTotalPrice.ToString();
        Console.WriteLine("\n\nU heeft "+amountTickets +" tickets gekozen, dit kost " +ticketsTotalPriceStr);
    }
