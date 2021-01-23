    public LinearGradientBrush(GradientStopCollection gradientStopCollection,
                               double angle) : base (gradientStopCollection)
    {
        EndPoint = EndPointFromAngle(angle);
    }
    private Point EndPointFromAngle(double angle)
    {
         // Convert the angle from degrees to radians
         angle = angle * (1.0/180.0) * System.Math.PI;
 
         return (new Point(System.Math.Cos(angle), System.Math.Sin(angle)));            
    }
