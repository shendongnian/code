    public override bool Equals(object other)
    {
        return this.Equals(other as CaseInsensitiveString);
    }
    public override int GetHashCode()
    {
        return this.Normalized.GetHashCode();
    }
    public static bool operator ==(CaseInsensitiveString x, CaseInsensitiveString y)
    {
        if (object.ReferenceEquals(x, null)
        {   // x is null, true if y also null
            return y==null;
        }
        else
        {   // x is not null
            return x.Equals(y);
        }
    }
    public static bool operator !=(CaseInsensitiveString x, CaseInsensitiveString y)
    {
        return !operator==(x, y);
    }
