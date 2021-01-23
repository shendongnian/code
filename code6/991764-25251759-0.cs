    public static class C
    {
        static B _theB = new B();
    
        public static double GetValue()
        {
            double result = 0;
            result = _theB.TMA(); 
            return result;
        }
    }
