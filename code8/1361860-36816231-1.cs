    public abstract class Item
    {
      public int id { get; set; }
    
      public virtual void ParseId(string line)
      {
        id = int.Parse(line);
      }
    }
