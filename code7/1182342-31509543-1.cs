    public class WrapPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            // Just take up all of the width
            Size finalSize = new Size { Width = availableSize.Width };
            double x = 0;
            double rowHeight = 0d;
            foreach (var child in Children)
            {
                // Tell the child control to determine the size needed
                child.Measure(availableSize);
                x += child.DesiredSize.Width;
                if (x > availableSize.Width)
                {
                    // this item will start the next row
                    x = child.DesiredSize.Width;
                    // adjust the height of the panel
                    finalSize.Height += rowHeight;
                    rowHeight = child.DesiredSize.Height;
                }
                else
                {
                    // Get the tallest item
                    rowHeight = Math.Max(child.DesiredSize.Height, rowHeight);
                }
            }
            // Just in case we only had one row
            if (finalSize.Height == 0)
            {
                finalSize.Height = rowHeight;
            }
            return finalSize;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            Rect finalRect = new Rect(0, 0, (finalSize.Width / 2) - 10, finalSize.Height);
            double EvenItemHeight = 0;
            double OddItemHeight = 0;
            int itemNumber = 1;
            foreach (var child in Children)
            {
                if (itemNumber % 2 == 0)
                {
                    finalRect.X = (finalSize.Width / 2);
                    finalRect.Y = EvenItemHeight;
                    EvenItemHeight += Children[itemNumber - 1].DesiredSize.Height;
                }
                else
                {
                    finalRect.X = 0;
                    finalRect.Y = OddItemHeight;
                    OddItemHeight += Children[itemNumber - 1].DesiredSize.Height;
                }
                itemNumber++;
                child.Arrange(finalRect);
            }
            return finalSize;
        }
    }
