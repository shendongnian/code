    struct SimpleStruct
    {
        private int xval;
    
        public int X
        {
            get 
            {
                return xval;
            }
            set 
            {
                if (value < 100)    xval = value;
            }
        }
    
        public void DisplayX()
        {
            Console.WriteLine("The stored value is: "+xval);
        }
    }
