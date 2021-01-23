    abstract Shape
    {
        public abstract double Area { get; }
    }
    
    sealed Circle : Shape
    {
        public override double Area 
        {
            get { /* logic */ } 
        }
    }
