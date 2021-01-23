    public class ItemIdComparer<Item>
    {
      public bool Equals(Item left, Item right)
      {
        return left.Id == right.Id;
      }
      public int GetHashCode(Item item)
      {
        return item.Id.GetHashCode();
      }
    }
