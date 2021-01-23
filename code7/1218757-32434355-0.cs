    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + FirstName.GetHashCode();
        hash = hash * 31 + LastName.GetHashCode();
        return hash;
    }
