    class Health : BMI
    {
        private int newSize;
    
        public Health(int Size, string Name, int Height, double Weight)
            : base(Name, Height, Weight)
        {
            newSize = Size;
        }
    }
