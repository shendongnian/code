     public class MyUniformGrid :  VirtualizingStackPanel
    {
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns", typeof(int), typeof(MyUniformGrid), new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public int Columns
        {
            set { SetValue(ColumnsProperty, value); }
            get { return (int)GetValue(ColumnsProperty); }
        }
        private int Rows
        {
            get
            {                
                return (InternalChildren.Count + Columns - 1) / Columns;
            }
        }
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            base.MeasureOverride(sizeAvailable);
            var sizeChild = new Size(sizeAvailable.Width / Columns, sizeAvailable.Height / Rows);
            double maxwidth = 0;
            double maxheight = 0;
            foreach (UIElement child in this.InternalChildren)
            {
                child.Measure(sizeChild);
                maxwidth = Math.Max(maxwidth, child.DesiredSize.Width);
                maxheight = Math.Max(maxheight, child.DesiredSize.Height);
            }
            return new Size(Columns * maxwidth, Rows * maxheight);
            
        }
        protected override Size ArrangeOverride(Size sizeFinal)
        {
            base.ArrangeOverride(sizeFinal);
            var sizeChild = new Size(sizeFinal.Width / Columns, sizeFinal.Height / Rows);
            for (var index = 0; index < InternalChildren.Count; index++)
            {
                var row = index / Columns;
                var col = index % Columns;
                var rectChild = new Rect(new Point(col * sizeChild.Width, row * sizeChild.Height), sizeChild);
                InternalChildren[index].Arrange(rectChild);
            }
            return sizeFinal;
        }
    }
