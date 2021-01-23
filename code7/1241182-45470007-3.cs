    public class ZenDeskTickets
    {
        [JsonProperty("tickets")]
        public Ticket[] Tickets { get; set; }
        [JsonProperty("next_page")]
        public object NextPage { get; set; }
        [JsonProperty("previous_page")]
        public object PreviousPage { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
