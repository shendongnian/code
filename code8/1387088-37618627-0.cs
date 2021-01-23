        public void NewValue(int newValue)
        {
          Low = Math.Min(Low, newValue);
          High = Math.Max(High, newValue);
        }
        public int LowestValue
        {
            get
            {
                return Low;
            }
            set
            {
                Low = value;
            }
        }
        public int HighestValue
        {
            get
            {
                return High;
            }
            set
            {
                High = value;
            }
        }
    }
