    public class SimpleDrawDown
    {
        public double Peak { get; set; }
        public double Trough { get; set; }
        public double MaxDrawDown { get; set; }
        public SimpleDrawDown()
        {
            Peak = double.NegativeInfinity;
            Trough = double.PositiveInfinity;
            MaxDrawDown = 0;
        }
        public void Calculate(double newValue)
        {
            if (newValue > Peak)
            {
                Peak = newValue;
                Trough = Peak;
            }
            else if (newValue < Trough)
            {
                Trough = newValue;
                var tmpDrawDown = Peak - Trough;
                if (tmpDrawDown > MaxDrawDown)
                    MaxDrawDown = tmpDrawDown;
            }
        }
    }
