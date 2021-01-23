    public class FindNegativeResult {
      public int Index {get;set;}
      public int Number {get;set;}
    }
    public static IEnumerable<FindNegativeResult> FindNegative(int[] array)
    {
        return array.Where(x=>x<0)
          .Select((e,i)=>new FindNegativeResult {Index=i, Number=e});
    }
