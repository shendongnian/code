    class Certificate
    {
        // Other properties ...
        public ICollection<TrainingSchedule> TrainingSchedules { get; set; }  
        public ICollection<Registration> Registrations { get; set; }  
    }
    
    class TrainingSchedule
    {
        // Other properties ...
        public Certificate Certificate { get; set; }  
    }
    
    class Registration
    {
        // Other properties ...
        public Certificate Certificate { get; set; }  
    }
