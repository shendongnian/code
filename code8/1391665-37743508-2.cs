	public class Point { 
		public virtual double sideA { get; set; } 
		public virtual double sideB { get; set; }
		public virtual double radius { get; set; }
		public virtual double height { get; set; }
	}
	
	public class RightTriangle:Point { 
		public override double sideA { get; set; }
		public override double sideB { get; set; }
	}
