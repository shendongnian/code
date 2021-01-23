    public class Circle : Shape
    {
        public int Radius { get; set; }
        
        public Circle(int radius) {
        	this.Radius = radius;
        }
		public override double Area() { return 3.14 * this.Radius * this.Radius; }
    }
    public class Rectangle : Shape
    {
       public int Length { get; set; }
       public int Breadth { get; set; }
       public Rectangle(int lenght, int breadth) {
       		this.Length = lenght;
       		this.Breadth = breadth;
       }
       public override double Area()
       {
            return Length * Breadth;
       }
    }
