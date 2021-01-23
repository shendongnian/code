        public double LongSide { get; set; }
        public double ShortSide { get; set; }
        public Layout(string layoutString)
        {
            string[] dimensions = layoutString.Split('x');
            this.LongSide = double.Parse(dimensions[0]);
            this.ShortSide = double.Parse(dimensions[1]);
        }
    }`
