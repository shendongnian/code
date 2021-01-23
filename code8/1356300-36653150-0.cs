    public class LineViewModel
    {
        public bool IsAutoScale { get; set; }
        public double Scale { get; set; }
        public bool IsReadOnly => !IsAutoScale;
    }
