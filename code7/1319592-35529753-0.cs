    private class BarEvent
    {
        public readonly DateTime Time;
        public readonly double Value;
        public BarEvent(double value)
        {
           Value = value;
           Time = DateTime.Now;
        }
    }
