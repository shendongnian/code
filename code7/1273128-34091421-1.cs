    public struct Point : IEquatable<Point>
    {
      private int _x;
      private int _y;
      public int X
      {
        get { return _x; }
        set { _x = value; }
      }
      public int Y
      {
        get { return _y; }
        set { _y = value; }
      }
      public Point(int x, int y)
      {
        _x = x;
        _y = y;
      }
      public bool Equals(Point other)
      {
        return X == other.X && Y == other.Y;
      }
      public override bool Equals(object other)
      {
        return other is Point && Equals((Point)other);
      }
      public int GetHashCode()
      {
        return unchecked(X * 1021 + Y);
      }
    }
