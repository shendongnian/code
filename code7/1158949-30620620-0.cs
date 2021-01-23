    public override bool Equals(Location other)
    {
        return this.State.Equals(other.State);
    }
    
    public override int GetHashCode()
    {
        return this.State.GetHashCode();
    }
