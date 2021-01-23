	public class B : List<A>
	{
		public B(IEnumerable<A> items)
		{
			base.AddRange(items);
		}
	}
