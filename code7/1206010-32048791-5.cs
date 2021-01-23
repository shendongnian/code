    protected override Size MeasureOverride(Size availableSize)
    {
        double min = Math.Min(availableSize.Width / Columns, availableSize.Height / Rows);
        SquareSideLength = (int)min;
        foreach (UIElement element in InternalChildren)
        {
            element.Measure(new Size(SquareSideLength, SquareSideLength));
        }
        return new Size(SquareSideLength * Columns, SquareSideLength * Rows);
    }
