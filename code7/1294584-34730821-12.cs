        interface IAIParam
        {
             int Previous { get; set; }
             // other params
        }
        
        void AI(IAIParam p)
        {
           p.Previous += 1; 
           //....
        }
    
