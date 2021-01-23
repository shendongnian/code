        static double angle(int h, int m)
        {
            double hAngle = 0.5D * (h * 60 + m);
            double mAngle = 6 * m;
            double angle = Math.Abs(hAngle - mAngle);
            return Math.Min(angle, 360 - angle);
        }
