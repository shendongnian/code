    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Event> organizingEvents { get; set; }
        public virtual ICollection<Event> attendingEvents { get; set; }
    }
    
    public class Event
    {
        [Key]
        public Guid Id { get; set; }
        public string name { get; set; }
    
        [ForeignKey("organizer")]
        public Guid organizerId { get; set; }
        public virtual Employee organizer { get; set; }
    
        public virtual ICollection<Employee> attendees { get; set; }
    }
