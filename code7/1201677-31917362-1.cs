    public class Item : IEquatable<Item>
    {
      public string Name { get; set; }
      public override int GetHashCode()
      {
          return Name == null ? 0 : Name.GetHashCode();
      }
      public bool Equals(Item other)
      {
        return other != null && Name == other.Name;
      }
      public override bool Equals(object obj)
      {
        return Equals(obj as Item);
      }
    }
