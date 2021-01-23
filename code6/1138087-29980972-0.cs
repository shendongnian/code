            if (ticketsReserved == numberOfTickets)
            { 
               LineItemModel lineModel = new LineItemModel(); 
               //Fill LineItemModel from webpapi
            }
            return PartialView("TicketList", lineModel );  //<-- here
