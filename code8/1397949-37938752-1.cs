	public class objAEqualityComparer : IEqualityComparer<objA>
	{
		public bool Equals(objA left, objA right)
		{
			return
				left.foo1 == right.foo1
				&& left.foo2 == right.foo2
				&& left.foo3 == right.foo3;
		}
		
		public int GetHashCode(objA @this)
		{
			return
				@this.foo1.GetHashCode()
				^ @this.foo2.GetHashCode()
				^ @this.foo3.GetHashCode();
		}
	}
