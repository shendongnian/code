    public bool Equals(DiePrint x, DiePrint y)
    {
        if (x == null && y == null)
        {
            return true;
        }
        else if (x == null || y == null) 
        {
            return false;
        }
        else
        {
            return x.Name == y.Name;
        }
    }
