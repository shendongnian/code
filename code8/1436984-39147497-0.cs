    public class Event
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        
        public int ContactId {get ; set;}
        [ForeignKey("ContactId")]
        public virtual User Contact { get; set; } 
    
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<User> Users { get; set; }    // These are the guides
        public virtual ICollection<Equipment> Equipments { get; set; }
        [Required]
        public EventType Type { get; set; }
    }
