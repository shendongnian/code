    public class MyClass 
    {
      public System.Windows.Size WSize = new System.Windows.Size();
      public MyDrawingSize DSize = new System.Drawing.Size();
      public class MyDrawingSize
      {
        public int Height, Width;
        public MyDrawingSize() { } //Needed for deserialization
        public MyDrawingSize(int width, int height)
        {
          Width = width;
          Height = height;
        }
        public static implicit operator System.Drawing.Size(MyDrawingSize size)
        {
          return new System.Drawing.Size(size.Width, size.Height);
        }
        public static implicit operator MyDrawingSize(System.Drawing.Size size)
        {
          return new MyDrawingSize() { Width = size.Width, Height = size.Height };
        }
      }
    }
