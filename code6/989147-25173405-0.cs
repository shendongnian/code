    public static string AlphaSort(string S)
      {        
        var Arr = S.Replace(" ", "").Split(' ');
        var NewS = Arr.ToList();
        var SortedS = NewS.OrderBy(c => c).ToList();
        return String.Join("", SortedS.ToArray());
      }
