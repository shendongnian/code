    public ActionResult Create(int ID) // assumes ID is the ID of the Event
    {
      // Get the event and its tickets
      Event e = db.Events.Where(e = e.EventID = ID).Include(e => e.Tickets);
      // Initialize a new order
      OrderVM model = new OrderVM
      {
        EventID = e.EventID,
        EventName = e.EventName,
        // other properties of event as required
        Tickets = e.Tickets.Select(t => new TicketVM
        {
          TicketID = t.TicketID,
          Description = t.Description,
          Price = t.Price
        })
      };
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(OrderVM model)
    {
      if (!ModelState.IsValid)
      {
        // repopulate any properties as required
        return View(model);
      }
      // Initialize an Order data model, save it and gets its ID
      Order order = new Order
      {
        OrderDate = model.OrderDate,
        // other properties of Order
      };
      db.Orders.Add(order);
      db.SaveChanges();
      // ditto for OrderDetails (but see notes above)
      // Initialize an TicketsOrdered data model for each valid ticket
      foreach(TicketVM ticket in model.Tickets.Where(t => t.Quantity > 0))
      {
        TicketsOrdered ticketOrder = new TicketsOrdered
        {
          OrderID = order.ID,
          TicketID = ticketOrder.TicketID,
          Quantity = ticketOrder.Quantity
        }
        db.TicketsOrdered.Add(ticketOrder);
      }
      db.SaveChanges();
      return RedirectToAction(...);
    }
