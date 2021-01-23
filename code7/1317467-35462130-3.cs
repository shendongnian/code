    public int Divide(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (Exception ex)
        {
            throw new MyLoggedException(a, b, ex);
        }
    }
