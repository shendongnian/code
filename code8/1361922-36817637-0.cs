    public override bool Equals(object other)
    {
        if (other is IGene)
            return Equals((IGene)other);
        return base.Equals(other);
    }
