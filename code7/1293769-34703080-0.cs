    {
        string line = myReader.ReadLine();
        var point = Point.Parse(line);
    }
    public struct Point
    {
        readonly int x, y, z;  // Always make struct immutable
        public Point(int x,int y,int z)
        {
           this.x = x;
           this.y = y;
           this.z = z;
        }
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int Z { get { return z; } }
        public static Point Parse(string line)
        {
          var parts = line.Split(stringSeperators, StringSplitOptions.RemoveEmptyEntries);
          var array = parts.Select( (s)=> s.ParseInt() ).ToArray();
          if(array.Length>=3) 
          {
              return new Point(array[0],array[1],array[2]);
          }      
          throw new IndexOutOfRangeException();
        }
    }
    // Example extensions for parsing strings
    public static class Extensions
    {
        public int ParseInt(this string value)
        {
            int x = 0;
            int.TryParse(value, out x);
            return x;
        }
        public float ParseFloat(this string value)
        {
            float x = 0;
            float.TryParse(value, out x);
            return x;
        }
    }
