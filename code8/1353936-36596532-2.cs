    public class Brand 
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool DeadBrand { get; set; }
        public string Name { get; set; }
    
        //navigation properties
        public ICollection<Event> Events { get; set; }
    }
    
    public class Event
    {           
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }        
        public DateTime EventCloseDate {get;set;}        
        public int PaxAllocationLimit { get; set; }
    
        //navigation properties             
        public Brand Brand { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
    
    public class Session
    {       
        public int Id { get; set; }
        public string Name { get; set; }   
        //Datetime contains date and time        
        public DateTime Time { get; set; } 
        //TimeSpan is for duration, allowing access to seconds, minutes, hours etc.
        public TimeSpan Duration { get; set; } 
        public DateTime? ArrivalTime { get; set; }
        public int SessionCapacity { get; set; }
    
        //navigation properties        
        public Event Event { get; set; }            
    }
