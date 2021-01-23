    public int CompareTo(object obj)
    {
    	if (obj == null)
    		return 1;
    	return this.ToString().CompareTo(obj.ToString());
    }
    public override int GetHashCode()
    {
    	unchecked
    	{
    		return ((PackageName != null ? PackageName.GetHashCode() : 0)*397) ^ (Version != null ? Version.GetHashCode() : 0);
    	}
    }
    public override string ToString()
    {
    	return string.Format("PackageName: {0}, Version: {1}", PackageName??"", Version ?? "");
    }
