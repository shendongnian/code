    protected bool Equals(Contract other)
    {
        return Id.Equals(other.Id) && string.Equals(Name, other.Name);
    }
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Contract) obj);
    }
    public override int GetHashCode()
    {
        unchecked
        {
            return (Id.GetHashCode()*397) ^ (Name != null ? Name.GetHashCode() : 0);
        }
    }
