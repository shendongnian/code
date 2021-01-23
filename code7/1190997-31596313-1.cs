    struct TVector3i
    {
        private int[] values = new int[3];
    
        public int this[int i]
        {
            get
            {
                return values[i];
            }
            set
            {
                values[i] = value;
            }
        }
    }
