    public class Rectangle : ShapeBase
    {
      public int Width {get; set;}
      public int Height {get; set;}
    }
    public class Block : Rectangle
    {
      public Size Size {get; set;}
    }
