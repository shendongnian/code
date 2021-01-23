	public class ShapeObj
	{
		public Point Location { get; set; }
		public Size Size {get; set; }
		public bool InsideTheObject(int x, int y)
		{
			Rectangle rc = new Rectangle(this.Location, this.Size);
			return rc.Contains(x, y);
		}
	}
