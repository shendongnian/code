    public static bool IsSortedAscOrDesc(int[] arr)
    {
        int last = arr.Length - 1;
        if (last < 1) return true;
        bool isSortedAsc = true;
        bool isSortedDesc = true;
        int i = 0;
        while (i < last && (isSortedAsc || isSortedDesc)) 
        {
            isSortedAsc &= (arr[i] <= arr[i + 1]);
            isSortedDesc &= (arr[i] >= arr[i + 1]);
            i++;
        }
        return isSortedAsc || isSortedDesc;
    }
