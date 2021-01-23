    public struct MyNumber
    {
    public MyNumber(double rPart1,double iPart1,double rPart2,double iPart2){//Set fields value}
        private double rPart1;
        private double iPart1;
        private double rPart2;
        private double iPart2;
        public  double X { get { return rPart1 + rPart2 ; } }
        public  double Y { get { return iPart1 + iPart2; } }
        public  string Sum(string format)
        {
           return string.Format(format, X, Y);
         }
      }
