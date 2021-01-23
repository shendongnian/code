	public class Rectangle
	{
		public Rectangle(double length, double width)
		{
			this.Length = length;
			this.Width = width;
		}
	
		public double Length { get; set; }
		public double Width { get; set; }
		public double Area { get { return this.Width * this.Length; } }
		public double Perimeter { get { return 2.0 * (this.Width + this.Length); } }
		public double Diagonal { get { return Math.Sqrt(Math.Pow(this.Width, 2.0) + Math.Pow(this.Length, 2.0)); } }
	}
