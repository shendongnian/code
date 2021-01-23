    var bookingData = (from con in context.bookings
        join agn in context.agents on con.main_agent_id equals agn.code
        select new { // Construct an anonymous type with the relevant parts
            Product = con.product_name,
            ActivityData = (from con1 in context.bookings
                          join acp in context.booking_activity on con1.code equals acp.booking_code
                          join agn in context.agents on con1.main_agent_id equals agn.code
                          join act in context.activities on acp.activity_code equals act.code
                          select act.name),
            ReservationCode = con.main_agent_voucher,
            DateOfActivity = (DateTime)con.date_of_activity,
            Notes = con.notes,
            Quantity = (int)con.pax,
            SubAgentName = con.sub_agent_name,
            ClientName = con.client_name,
            MainAgent = agn.agent_name,
            Consultant2 = con.sub_agent_consultant                                      
        }).AsEnumerable() // Bring this into memory
        .Select(p => new POS_LINK.BusinessObjects.Bookings {
            Product = p.Product,
            Activity = string.Join(", ", p.ActivityData.ToArray()),
            ReservationCode = p.ReservationCode,
            CostOfSale = 0.00M,
            Notes = p.Notes,
            Quantity = p.Quantity,
            Child_quantity = 0,
            Child_cost_percentage = 0,
            CostPerPerson = 0.00M,
            SubAgentRef = "56789",
            SubAgentName = p.SubAgentName,
            ClientName = p.ClientName,
            MainAgent = p.MainAgent,
            Consultant2 = p.Consultant2  
        });
    return bookingData.ToList();
