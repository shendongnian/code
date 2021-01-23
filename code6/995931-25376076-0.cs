	namespace Model
	{
		public class Example : IEnumerable<double>
		{
			private double vars = new double[5];
		
			protected double this[int ix]
			{
				get { return vars[ix]; }
				set { vars[ix] = value; }
			}
			public IEnumerator<double> GetEnumerator()
			{
				return vars;
			}
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<double>)this).GetEnumerator();
			}
		}
	}
