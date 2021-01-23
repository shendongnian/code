    public class TreemapItem {
        private TreemapItem() {
            FillBrush = Brushes.White;
            BorderBrush = Brushes.Black;
            TextBrush = Brushes.Black;
        }
        public TreemapItem(string label, int area, Brush fillBrush) : this() {
            Label = label;
            Area = area;
            FillBrush = fillBrush;
            Children = null;
        }
        public TreemapItem(params TreemapItem[] children) : this() {
            // in this implementation if there are children - all other properies are ignored
            // but this can be changed in future
            Children = children;
        }
        // Label to write on rectangle
        public string Label { get; set; }
        // color to fill rectangle with
        public Brush FillBrush { get; set; }
        // color to fill rectangle border with
        public Brush BorderBrush { get; set; }
        // color of label
        public Brush TextBrush { get; set; }
        // area
        public int Area { get; set; }
        // children
        public TreemapItem[] Children { get; set; }
    }
