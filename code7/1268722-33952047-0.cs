    public override bool Equals(object obj)
    {
        IdDataClass otherObject = obj as IdDataClass;
        if (otherObject == null)
            return false;
        else
            return Equals(otherObject );
    }
    public override int GetHashCode()
    {
        return _ID.GetHashCode() + _MyData.GetHashCode();
    }
