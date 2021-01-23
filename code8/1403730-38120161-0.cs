    public int? ParseToNullable(string s)
    {
        int? result = null;
        int temp = 0;
        if (int.TryParse(s, out temp)) 
        {
             result = temp;
        }
        return result;
    }
