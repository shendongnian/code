    public class UniformGridSingleLine : Panel
    {
      protected override Size MeasureOverride(Size availableSize)
      {
        foreach (UIElement child in Children)
          child.Measure(availableSize);
        return new Size(double.IsPositiveInfinity(availableSize.Width) ? 0 : availableSize.Width,
            double.IsPositiveInfinity(availableSize.Height) ? Children.Cast<UIElement>().Max(x => x.DesiredSize.Height) : availableSize.Height);
      }
      protected override Size ArrangeOverride(Size finalSize)
      {
        Size cellSize = new Size(finalSize.Width / Children.Count, finalSize.Height);
        int col = 0;
        foreach (UIElement child in Children)
        {
          child.Arrange(new Rect(new Point(cellSize.Width * col, 0), new Size(cellSize.Width, child.DesiredSize.Height)));
          col++;
        }
        return finalSize;
      }
    }
