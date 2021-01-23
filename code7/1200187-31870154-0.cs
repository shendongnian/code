	public class Point
	{
		public string X {get; protected set;}
		public string Y {get; protected set;}
		public Point(string x, string y)
		{
			X = x;
			Y = y;
		}
		public HashSet<string> GetSet()
		{
			HashSet<string> result = new HashSet<string>();
			result.Add(this.X);
			result.Add(this.Y);
			return result;
		}
	}
