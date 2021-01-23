    public abstract class Item
    {
      public int id { get; set; }
    
      public void ParseId(string line)
      {
        id = int.Parse(line);
      }
    }
