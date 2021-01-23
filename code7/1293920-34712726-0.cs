    public class TicketVM
    {
      public int TicketID { get; set; }
      public string Description { get; set; }
      public decimal Price { get; set; }
      public int Quantity { get; set; }
    }
    public class OrderVM
    {
      public int ID { get; set; }
      public int EventID { get; set; }
      public string EventName { get; set; }
      // additional properties of Event you want to display
      public DateTime OrderDate { get; set; }
      public string FirstName { get; set; }
      // additional properties of Order and OrderDetails you want to edit
      public List<TicketVM> Tickets { get; set; }
    }
