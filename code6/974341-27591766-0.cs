    Class Y 
    {
        public int Id { get; set; }
        public ICollection<X> Xs { get; set; }
    }
    
    Class X 
    {
        public int Id { get; set; }
        public int YId { get; set; }   
        public Y Y { get; set; }
    }
