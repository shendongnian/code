    public abstract class Chart
    {
        // Public properties common to all charts
        public ChartData data;
        public ChartStyle style;
        public string RowNumber { get; set; }
        public string UniqueName { get; set; }
        // A common method    
        public void AddDataPoint () {}
        // A method all charts have that may change between different types of charts
        public virtual void DrawChart () {}
        // Constructor
        public Chart (ChartData cd, ChartStyle cs)
        {
            data = cd;
            style = cs;
        }
        // Protected method (like a private method, but gets inherited)
        protected void Finalize () {}
    }
