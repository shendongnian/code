    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
       // Data members, in order, matching the Win32 RECT structure:
       public int Left;
       public int Top;
       public int Right;
       public int Bottom;
    
       // Constructor:
       public RECT(int left, int top, int right, int bottom)
       {
         this.Left  = left;
         this.Top   = top;
         this.Right = right;
         this.Bottom = bottom;
       }
    
       // Convenience properties:
       
       public int Width
       {
         get  { return this.Right - this.Left; }
         set  { this.Right = value + this.Left; }
       }
       
       public int Height
       {
         get  { return this.Bottom - this.Top; }
         set  { this.Bottom = value + this.Top; }
       }
       // Conversion helper functions:    
      public System.Drawing.Point Position
      {
         get  { return new System.Drawing.Point(this.Left, this.Top); }
      }
      public System.Drawing.Size Size
      {
         get  { return new System.Drawing.Size(this.Width, this.Height); }
      }
    }
