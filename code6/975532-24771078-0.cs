    Bool Test = IsRoughlyEqual(.0001, .0002, .01);
    
    public bool IsRoughlyEqual(double NumA, double NumB, double Tolerance)
    {
        double Result = Math.Abs(NumA - NumB);
    
        if (Result > Tolerance)
            return false;
        else
            return true;
    }
