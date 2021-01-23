    public class SquareGrid : Grid
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            availableSize = base.MeasureOverride(availableSize);
            return new Size(availableSize.Width, availableSize.Width);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            finalSize = base.ArrangeOverride(finalSize);
            Width = Height = finalSize.Width;
            return new Size(finalSize.Width, finalSize.Width);
        }
    }
