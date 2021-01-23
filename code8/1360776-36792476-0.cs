    class ArrayofFour
    {
        string[] a = new string[4];
        
        public string this[int i]
        {
            get
            {
                return a[i];
            }
            set
            {
                a[i] = value;
            }
        }
    }
