    public static bool is_empty(int[] S)
    {
        // return true if no element is 0
        return !S.Any(x => x != 0);
        // or use
        return S.All(x => x == 0);
    }
