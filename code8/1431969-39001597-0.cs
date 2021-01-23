    public class FilterAppliedEventArgs : EventArgs
    {
        public Filter FilterObject { get; set; }
        public FilterAppliedEventArgs(Filter filter)
        {
            this.FilterObject = filter;
        }
    }
