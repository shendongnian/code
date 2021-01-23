	public override int GetHashCode()
	{
		unchecked
		{
			int hash = 17;
			hash = hash * 23 + this.Item2.GetHashCode();
			foreach (var s in this.Item1)
			{
				hash = hash * 23 + s.GetHashCode();
			}
			return hash;
		}
	}
