    private Point traverseFunction(KeyValuePair<TKey, TValue> element, Point parentPosition, int depth, int xPos)
    {
        float x, y;
        x = xPos * (horizontalSpacing + horizontalSize);
        y = depth * (verticalSpacing + verticalSize);
        RectangleF rect = new RectangleF(x, y, horizontalSize, verticalSize);
        if(g.VisibleClipBounds.IntersectsWith(rect))
        {
            if(depth != treeHeight)
            {
                g.FillRectangle(Brushes.Black, x, y, horizontalSize, verticalSize);
                g.DrawString(element.Key.ToString(), SystemFonts.DefaultFont, Brushes.Gold, x + 2, y + 2);
            }
            else
            {
                g.FillRectangle(Brushes.Red, x, y, horizontalSize, verticalSize);
                g.DrawString(element.Key.ToString(), SystemFonts.DefaultFont, Brushes.White, x + 2, y + 2);
            }
            // Use the parent node's position to draw a line.
            g.DrawLine(new Pen(Color.Black, 3), parentPosition, new Point(x, y));
        }
        Console.WriteLine(key + " : " + depth);
        return new Point(x, y);
    }
