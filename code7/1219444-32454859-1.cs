    private int firstEmpty(string[] arr)
    {
        int res = 0;
    
        foreach (string item in arr)
        {
            if (String.IsNullOrEmpty(item))
            {
                return res;
            }
            res++;
        }
        
        return -1; // Array is full
    }
