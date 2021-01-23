    public class Size 
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Unit Unit { get; set; }
        public Size ConvertTo(Unit unit)
        {
             Size convertedSize;
             switch(unit) 
             {
                  case Unit.Inch:
                      // Calc here the conversion from current Size 
                      // unit to inches, and return
                      // a new size
                      convertedSize = new Size(...);
                      break;
                  
                  case Unit.Pixel:
                      // Calc here the conversion from current Size 
                      // unit to pixels, and return
                      // a new size
                      convertedSize = new Size(...);
                      break;
                  
                  default: throw new NotSupportedException("Unit not supported yet");
                 
             }
             return convertedSize;
        }
    }
