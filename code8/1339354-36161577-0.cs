     public class Employee
        {
            [Key]
            public Guid Id { get; set; }
            public string name { get; set; }
            public virtual ICollection<middle_table> Middle_table{ get; set; }
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
            public virtual ICollection<middle_table> Middle_table{ get; set; }
        }
        public class your_middle_class
        {
        public Guid Id { get; set; }
        public virtual Employee organizer { get; set; }
         public virtual Event Event{ get; set; }
        }
