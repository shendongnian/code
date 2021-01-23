	public class ColectionBaseEntityIdentifierDetailComparer 
      : IEqualityComparer<ICollection<BaseEntityIdentifierDetail>>
	{
		public bool Equals(ICollection<BaseEntityIdentifierDetail> left,
          ICollection<BaseEntityIdentifierDetail> right)
		{
			// compare left and right
			return true;
		}
		
		public int GetHashCode(ICollection<BaseEntityIdentifierDetail> obj)
		{
			// return correctly implemented GetHashCode()
			return 1; 
		}
	}
