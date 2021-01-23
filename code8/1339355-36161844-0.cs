	public class Employee
	{
		[Key]
		public Guid Id { get; set; }
		public string name { get; set; }
        [InverseProperty("atendees")]
		public virtual ICollection<Event> event { get; set; }
	}
	public class Event
	{
		[Key]
		public Guid Id { get; set; }
		public string name { get; set; }
		[ForeignKey("organizer")]
		public Guid organizerId { get; set; }
		public virtual Employee organizer { get; set; }
        [InverseProperty("event")]
		public virtual ICollection<Employee> atendees { get; set; }
	}
