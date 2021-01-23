    public int CompareTo(object obj)
    {
    	if (obj == null)
    		return 1;
    	return String.Compare(this.ToString(), obj.ToString(), StringComparison.Ordinal);
    }
    public override int GetHashCode()
    {
    	unchecked
    	{
    		return ((PackageName != null ? PackageName.GetHashCode() : 0)*397) ^ (Version != null ? Version.GetHashCode() : 0);
    	}
    }
