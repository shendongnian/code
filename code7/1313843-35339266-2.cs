    public bool IsNumber(string strToValidate)
    {
        foreach (char c in strToValidate)
        {
            if (c < '0' || c > '9')
                return false;
        }
        return true;
    }
