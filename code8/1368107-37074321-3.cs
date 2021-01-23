	public class Event2Location
	{
		[Required]
		public Event Event { get; set; }
		public int EventId { get; set; }
		[Required]
		public Location Location { get; set; }
		public int LocationId { get; set; }
		public byte EntityType { get; set; }
	}
