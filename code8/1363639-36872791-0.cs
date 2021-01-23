    public int RandomNumber
        {
            get
            {
                Random rnd = new Random();		
                return rnd.Next(0,11);
            }
    
            set
            {
                this = value;
            }
        }
