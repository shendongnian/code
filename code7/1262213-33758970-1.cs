        public static double RoundAt(double Number, int Position, int startUp)
        {
            double Up = Math.Abs(Number) * Math.Pow(10, Position);
            double temp = Up;
            double Out;
            while (Up > 0)
            {
                Up--;
            }
            Out = temp - Up;                           //Up
            if (Up < (Convert.ToDouble(startUp) - 10) / 10)
            { Out = temp - Up - 1; }                   //Down
            if (Number < 0)
            { Out *= -1; }
            Out /= Math.Pow(10, Position);
            return Out;
        }
