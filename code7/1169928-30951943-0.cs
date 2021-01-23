    public class FieldCompareItemComparer: IEqualityComparer<FieldCompareItem>
    {
      public bool Equals(FieldCompareItem x, FieldCompareItem y)
      {
        var result = x.Fields.SequenceEqual(y.Fields);
        return result;
      }
      public int GetHashCode(FieldCompareItem obj)
      {
        return String.Concat(obj.Fields).GetHashCode();
      }
    }
