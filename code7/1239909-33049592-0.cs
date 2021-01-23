    class MyColorClass
    {
         public byte Red { get; set; }
         public byte Green { get; set; }
         public byte Blue { get; set; }
         public MyColorClass(long color)
         {
             Red = (byte)((color >> 16) & 0xff);
             Green = (byte)((color >> 8) & 0xff);
             Blue = (byte)(color & 0xff);
         }
         public override string ToString()
         {
             return string.Format("R: {0} G: {1} B: {2}", Red, Green, Blue);
         }
     }
     static void Main(string[] args)
     {
         long lcolor = MakeRgb(50, 100, 150);
         MyColorClass color = new MyColorClass(lcolor);
         Console.WriteLine(color);
     }
