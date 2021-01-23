    public class MyPoint // Give it a unique name to avoid collisions
    {
       public int X { get; set; }
       public int Y { get; set; }
       public MyPoint() {} // Default constructor allows you to use object initialization.
       public MyPoint(int x, int y) { X = x, Y = y }
    }
