    class ship
    {
        protected int baseStat = 0;    //I want this to be protected - now it is
        private int derivedStat = 0; //This should also be protected - can even be private
        public int DerivedStat {
            get 
            {
                return derivedStat;
            }
            set
            {
                if(value < 0)
                    throw new Exception("Validate your data here!");
                derivedStat = value;
            }
        }
    }
