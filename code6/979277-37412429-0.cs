    var customersWithRecentReservations = 
        from c in context.Contacts.OfType<Customer>()
        where c.FirstName == p_firstName && c.LastName == p_lastName 
        select new {Customer = c, Reservations = c.Reservations.Where(r => r.ReservationDate >= p_reservationDate)};
    
    var customers = customersWithRecentReservations.AsEnumerable().Select(p => p.Customer);
