    class Publisher
    {
        public event Action x;      
        
        public void Raise()
        {
           Action x = this.x;
           if (x != null)
              x(); // No parameters
        }
    }
