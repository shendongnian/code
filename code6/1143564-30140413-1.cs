    public static class Analyze
    {
        public static DataSet moodleData;  // Dataset containing the log data for analysis
        private static bool dataPresent = true;
        public static Boolean DataPresent
        {
            get { return dataPresent; }
            set
            {
                if (dataPresent != value)
                {
                    dataPresent = value;
                    DataPresentChanged(null, EventArgs.Empty);
                }
            }
        }
        public static event EventHandler DataPresentChanged = delegate { };
    }
