    public int[] MyNumberMethod(Number a, Number b)
    {
        try {
            return new int[] { Convert.ToInt32(b), Convert.ToInt32(a) };
        }
        catch(InvalidCastException) {
            return new int[] { 0, 0 };
        }
    }
