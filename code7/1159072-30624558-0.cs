    public override int GetHashCode()
    {
		var hashCode = Date.GetHashCode();
		hashCode = (hashCode * 37) ^ X.GetHashCode();
		hashCode = (hashCode * 37) ^ Y.GetHashCode();
        return hashCode;
    }
