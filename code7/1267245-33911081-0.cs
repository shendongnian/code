    public struct Banana
    {
        public Banana(string first, string second)
        {
            First = first;
            Second = second;
        }
        public string First;
        public string Second;
        public string TwoParts 
        { 
            get
            {
                return First + " " + Second;
            }
        }
    }
