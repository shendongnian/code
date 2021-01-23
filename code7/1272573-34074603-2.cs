    Compare(List<string> a, List<string> b)
    {
        if(a.Length == b.Length)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if(!b.Contains(a[i]))
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
