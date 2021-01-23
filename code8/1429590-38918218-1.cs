    List<Component> components = new List<Component>();
    var result = components.GroupBy(c => c.Paxes, new PaxesComparer());
	public class PaxesComparer : IEqualityComparer<IEnumerable<Pax>>
	{
		public bool Equals(IEnumerable<Pax> x, IEnumerable<Pax> y)
		{
            throw new NotImplementedException();
		}
		public int GetHashCode(IEnumerable<Pax> obj)
		{
			throw new NotImplementedException();
		}
	}
