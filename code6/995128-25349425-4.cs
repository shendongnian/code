        public class CustomPanel : Panel
    {
        //TODO :Create as Attached Property
        public int Columns { get; set; }
        // Default public constructor 
        public CustomPanel(): base()
        {
        }
        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = ArrangeAndMeasure(availableSize, true);
            if (double.IsInfinity(availableSize.Height) || double.IsInfinity(availableSize.Width))
                return size;
            else
                return availableSize;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            return ArrangeAndMeasure(finalSize, false);
        }
        Size ArrangeAndMeasure(Size finalSize,bool isMeasure)
        {
            //if columns not specified set it value 1.
            Columns = Columns == 0 ? 1 : Columns;
            Size size = new Size(0, 0);
            double maxWidth = 0.0;
            int colCount = 1;
            foreach (UIElement child in InternalChildren)
            {
                if ((size.Height + child.DesiredSize.Height > finalSize.Height) && Columns >= colCount)
                {
                    //if all height consumed move to next column
                    size.Width += maxWidth;
                    size.Height = 0.0;
                    colCount++;
                }
                if (isMeasure)
                    child.Measure(finalSize);
                else
                    child.Arrange(new Rect(new Point(size.Width, size.Height), child.DesiredSize));
                size.Height += child.DesiredSize.Height;
                if (maxWidth < child.DesiredSize.Width)
                    maxWidth = child.DesiredSize.Width;
            }
            return size; 
        }
    }
