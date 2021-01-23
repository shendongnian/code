    public static void RotX(double angle, ref double y, ref double z)
         {
         double y1 = y * System.Math.Cos(angle) - z * System.Math.Sin(angle);
         double z1 = y * System.Math.Sin(angle) + z * System.Math.Cos(angle);
         y = y1;
         z = z1;
         }
    public static void RotY(double angle, ref double x, ref double z)
         {
         double x1 = x * System.Math.Cos(angle) - z * System.Math.Sin(angle);
         double z1 = x * System.Math.Sin(angle) + z * System.Math.Cos(angle);
         x = x1;
         z = z1;
         }
    public static void RotZ(double angle, ref double x, ref double y)
         {
         double x1 = x * System.Math.Cos(angle) - y * System.Math.Sin(angle);
         double y1 = x * System.Math.Sin(angle) + y * System.Math.Cos(angle);
         x = x1;
         y = y1;
         }
