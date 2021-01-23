    public class Overall
    {
        private static int _percentage;
        public static int PercentageDwnd
        {
            get { return _percentage; }
            set
            {
                _percentage = value;
                //raise event:
                if (PercentageDwndChanged != null)
                    PercentageDwndChanged(null, EventArgs.Empty);
            }
        }
        public static string caseRefId { get; set; }
        public static bool stopStatus { get; set; }
        public static event EventHandler PercentageDwndChanged;
    }
