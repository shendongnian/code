    public bool AComesBeforeB(int a, int b) 
    {
        if(IsOdd(a))
        {
            if(IsOdd(b))
            {
                return a < b;
            }
            else
            {
                return true;
            }
        }
        else
        {
            if(isOdd(b))
            {
                return false;
            }
            else
            {
                return a > b;
            }
        }
    }
