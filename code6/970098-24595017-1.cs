    public class MyClass
    {
      public double X { set; get; }
      public double Y { set; get; }
      public bool Unique { set; get; }
      public MyClass Duplicate()
      {
        Unique = false;
        return this;
      }
    }
    // So you call:
    
    var query = list.SelectMany(sublist => sublist)
                    .Where(item => item.X == x && item.Y == y)
                    .Select(item => item.Duplicate());
