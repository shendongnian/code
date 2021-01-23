    public Class Car
    {   // guessing here
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    
        public override string TosString()
        {
            return "Make: " + Make + ", Model: " + Model + ", Year: " + year;
        }
    
    }  
  
