    internal class Point3D
    {
        public double x = 0, y = 0, z = 0, PreviousX, PreviousY, PreviousZ;
    
        public void MoveTo(double NewX, double NewY, double NewZ)
        {
    
            PreviousX = x; // remember previous value to use in delta calculation
            x = NewX;
    
            PreviousY = y;
            y = NewY;
    
            PreviousZ = z;
            z = NewZ;
    
        }
    
        public double DistanceTo()
        {
            double DeltaX = Math.Pow((x - PreviousX), 2);
            double DeltaY = Math.Pow((y - PreviousY), 2);
            double DeltaZ = Math.Pow((z - PreviousZ), 2);
    
            return Math.Sqrt(DeltaX + DeltaY + DeltaZ);
    
        }
    }
