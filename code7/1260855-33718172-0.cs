	public sealed class CustomerByIdEqualityComparer : IEqualityComparer<Customer>
	{
		public bool Equals(Customer x, Customer y)
		{
			if (ReferenceEquals(x, y)) return true;
			if (ReferenceEquals(x, null)) return false;
			if (ReferenceEquals(y, null)) return false;
			if (x.GetType() != y.GetType()) return false;
			return x.CustomerId == y.CustomerId;
		}
	
		public int GetHashCode(Customer obj)
		{
			return obj.CustomerId;
		}
	}
	
	public sealed class CustomerByIdAndNameEqualityComparer : IEqualityComparer<Customer>
	{
		public bool Equals(Customer x, Customer y)
		{
			if (ReferenceEquals(x, y)) return true;
			if (ReferenceEquals(x, null)) return false;
			if (ReferenceEquals(y, null)) return false;
			if (x.GetType() != y.GetType()) return false;
			return !string.Equals(x.CustomerName, y.CustomerName) &&
					x.CustomerId == y.CustomerId;
		}
	
		public int GetHashCode(Customer obj)
		{
			return obj.CustomerId;
		}
	}
	
