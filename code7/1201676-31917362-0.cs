    public class Item
    {
      public string Name { get; set; }
      public override int GetHashCode()
      {
          return Name == null ? 0 : Name.GetHashCode();
      }
      public override bool Equals(object obj)
      {
        var asItem = obj as Item;
        return asItem != null && Name == obj.Name;
      }
    }
