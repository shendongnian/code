    public class CoordPoint : ICloneable
    {
      //rest of your code here
      public object Clone()
      {
        return new CoordPoint
                     {
                       X= X,
                       Y = Y
                     };
      }
    }
