    public override int GetHashCode()
    {
        // note that the value returned from ConvertToSomeBaseUnit
        // should probably be cached as a private member 
        // especially if your class is supposed to immutable
        return Value.ConvertToSomeBaseUnit().GetHashCode();
    }
