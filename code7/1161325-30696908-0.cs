    public override int GetHashCode()
    {
        unchecked
        {
            return (firstName.GetHashCode() * 33 ^ lastName.GetHashCode()) * 33 ^ phone.GetHashCode();
        }
    }
