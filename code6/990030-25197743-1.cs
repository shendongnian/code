    public static class Reports
    {
        public ReportsParameter<T> CreateParameter<T>
            (string name, T value = default(T))
        {
            return new ReportsParameter<T>(name, value);
        }
    }
