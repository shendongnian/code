    public class ByParentIdComparer : IEqualityComparer<Item>
    {
      public bool Equals(Item x, Item y)
      {
        return x.ItemParentId == y.ItemParentId;
      }
      public int GetHashCode(Item obj)
      { 
        return obj.ItemParentId;
      }
    }
