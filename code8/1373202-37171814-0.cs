    public DayOfWeek DayOfWeek 
    { 
     get {  
           return Tasks.First(t => t.StartDateTime).DayOfWeek; 
         }
     }
