    public class Card
    {
      public readonly string Name;
      public readonly string S;
      
      public Card(string Name, string S)
      {
        this.Name = Name;
        this.S = S;
      }
      
      public override ToString()
      {
        return Name;
      }
    }
