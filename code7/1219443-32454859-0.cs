    private int countArray(string[] arr)
    {
        int res = arr.Length;
    
        foreach (string item in arr)
        {
            if (String.IsNullOrEmpty(item))
            {
                res -= 1;
            }
        }
    
        return res;
    }
