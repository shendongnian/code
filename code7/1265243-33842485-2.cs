    public class NotMoreThanFive 
    {
      public int Value {get; private set;}
      public NotMoreThanFive(int value) 
      {
        Value = value > 5 ? 0 : value;
      }
    }
