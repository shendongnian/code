    public struct Point : IEquatable<Point>
    {
      public int X { get; set; }
      public int Y { get; set; }
      public Point(int x, int y)
      {
        X = x;
        Y = y;
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
