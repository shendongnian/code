    public class OutputViewModel
    {
        public decimal Number { get; set; }
        public object Mask { get; set; }
        public string NumberFormatted 
        {
            get { return FormatNumber(Number, Mask); }
        }
    }
