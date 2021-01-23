    public class CreateTicketVm
    {
        public int EventId { get; set; }
        public List<TicketVm> Tickets { set; get; }
    }
    public class TicketVm
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
    }
