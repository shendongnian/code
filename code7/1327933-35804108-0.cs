    public class RangeInfo
    {
       public RangeInfo(IList<int> range, string txt)
       {
          if (range == null || range.Count != 2)
             throw new ArgumentException(..);
          Range = range.ToArray();
          Info = txt;
       }
       public int[] Range { get; private set; }
       public string Info { get; private set; }
    }
