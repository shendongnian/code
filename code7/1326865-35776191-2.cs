    class LineViewModel
    {
        public PointCollection LinePoints { get; set; }
    }
    class ViewModel
    {
        public IEnumerable<LineViewModel> Lines { get; set; }
    }
