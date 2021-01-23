    class Program
    {
        static void Main(string[] args)
        {
            Apple a = new Apple("green");
        }
    }
    
    class Apple
    {
        private string _colour;
        public string Colour
        {
            get
            {
                return _colour;
            }
        }
    
        public Apple(string colour)
        {
            this._colour = colour;
        }
    
    }
