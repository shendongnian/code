    public Class B
    {
        public static void main(string[] args)
        {
            int s = 99;
            int w = Changeint(s); // w has changed
            int x = s; // s has also changed
        }       
    
        private int Changeint(ref int s)
        {
                s += 30; // result = 129
                return s;
        }
    }
