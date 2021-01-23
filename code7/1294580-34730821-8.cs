        public IAIParam
        {
             int Previous { get; set; }
             // other params
        }
        
        void AI(IAIParam p)
        {
           p.previous += 1; 
           //....
        }
    
