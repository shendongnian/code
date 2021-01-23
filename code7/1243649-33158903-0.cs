    public static double rad(double deg)
    {
        return deg * Math.PI / 180;  
    }
    public static double thirdside(double side1, double side2, double angleDeg)
    {
        double angleRad = rad(angleDeg);
        return Math.Sqrt(side1*side1 + side2*side2 - 2*side1*side2*Math.Cos(angleRad));
    }
