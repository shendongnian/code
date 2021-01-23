    class Rectangle : Shape
    {
        public Rectangle() {
            NumberOfCorners = 4;
        }
    
        public override void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }
    
        public int NumberOfCorners { get; set; };
    } 
