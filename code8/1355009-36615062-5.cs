    public static int GetClosestIndex(int[] arr, int value)
    {
        var result = arr.Where(x => x < value).OrderByDescending(x => x);
        return result.Any() ? Array.IndexOf(arr, result.FirstOrDefault()) : -1;
    }
