    private int Divide(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (Exception ex)
        {
            ex.Data["a"] = a;
            ex.Data["b"] = b;
            throw; //NOT throw ex;
        }
    }
