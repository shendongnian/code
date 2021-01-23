    public byte BoolsToByte(IEnumerable<bool> bools)
    {
        byte result = 0;
        foreach ( bool value in bools )
        {
            result *= 2;
            if ( value )
                result += 1;
        }
        return result;
    }
