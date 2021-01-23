    class Segment
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
        public Bitmap Bitmap { get; set; }
        public Segment()
        {
            Left = int.MaxValue;
            Right = int.MinValue;
            Top = int.MaxValue;
            Bottom = int.MinValue;
        }
    };
