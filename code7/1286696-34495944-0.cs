	public class Foo
	{
		private List<double> doubles = new List<double> { 1.0, 2.0, 3.0 };
	
		public double this[int x]
		{
			get { return doubles[x]; }
			set { doubles[x] = value; }
		}
	}
