	public abstract class Shape
	{
		public string Type { get; private set; }
	
		public abstract double Area { get; }
		public Shape(string type)
		{
			this.Type = type;
		}
	}
	public class Rectangle : Shape
	{
		public double Length { get; private set; }
		public double Width { get; private set; }
	
		public Rectangle(string type, double width, double length)
			: base(type)
		{
			this.Width = width;
			this.Length = length;
		}
	
		public override double Area { get { return this.Width * this.Length; } }
	}
	
	public class BadRectangle : Rectangle
	{
		public bool BadOrNot { get; private set; } = false;
		
		public BadRectangle(string type, double width, double length, bool badOrNot)
			: base(type, width, length)
		{
			this.BadOrNot = badOrNot;
		}
	
		public string Status
		{
			get
			{
				string answer = "No, Rectangle is not bad";
				if (this.BadOrNot == true)
				{
					answer = "Yes, Rectangle is bad";
				}
				return answer;
			}
		}
	}
