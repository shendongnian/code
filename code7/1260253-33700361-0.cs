    public abstract class Chart
    {
        // Properties common to all charts
        public ChartData data;
        public ChartStyle style;
        public string UniqueName { get; set; }
        public string RowNumber { get; set; }
    
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
    }
