    public static string AlphaSort(string S)
    {
        var Arr = S.Replace(" ", "").ToCharArray();
        var SortedS = Arr.OrderBy(c => c);
        return String.Join("", SortedS);
    }
