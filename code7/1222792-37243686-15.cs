    private RectangleF emptyArea;
    private void DrawIn(Graphics g, float x, float y, float width, float height)
    {
        Measure(width, height);
        foreach (var item in Items)
        {
            var sFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            if (item.Children.Count() > 0)
            {
                g.FillRectangle(Brushes.DimGray, x + item.TMData.Location.X, y + item.TMData.Location.Y, item.TMData.Size.Width, 15);
                g.DrawString(item.Name, SystemFonts.DefaultFont, Brushes.LightGray, new RectangleF(x + item.TMData.Location.X, y + item.TMData.Location.Y, item.TMData.Size.Width, 15), sFormat);
                var treeMap = new TreeMap(item.Children);
                treeMap.DrawIn(g, x + item.TMData.Location.X, y + item.TMData.Location.Y + 15, item.TMData.Size.Width, item.TMData.Size.Height - 15);
            }
            else
            {                    
                g.FillRectangle(new SolidBrush(item.Data.Color), x + item.TMData.Location.X, y + item.TMData.Location.Y, item.TMData.Size.Width, item.TMData.Size.Height);
                g.DrawString(item.Name, SystemFonts.DefaultFont, Brushes.Black, new RectangleF(x + item.TMData.Location.X, y + item.TMData.Location.Y, item.TMData.Size.Width, item.TMData.Size.Height), sFormat);
            }
            var pen = new Pen(Color.Black, item.GetDepth() * 1.5f);
            g.DrawRectangle(pen, x + item.TMData.Location.X, y + item.TMData.Location.Y, item.TMData.Size.Width, item.TMData.Size.Height);
        }
        g.Flush();
    }
    private void Measure(float width, float height)
    {
        emptyArea = new RectangleF(0, 0, width, height);
        var area = width * height;
        var sum = Items.Sum(t => t.Data.Area + 1);
        foreach (var item in Items)
        {
            item.TMData = new TreeMapData();
            item.TMData.Area = area * (item.Data.Area + 1) / sum;
        }
        Squarify(Items, new List<Item>(), ShortestSide());
        foreach (var child in Items)
            if (!IsValidSize(child.TMData.Size))
                child.TMData.Size = new Size(0, 0);
    }
    private void Squarify(IEnumerable<Item> items, IEnumerable<Item> row, float sideLength)
    {
        if (items.Count() == 0)
        {
            ComputeTreeMaps(row);
            return;
        }
        var item = items.First();
        List<Item> row2 = new List<Item>(row);
        row2.Add(item);
        List<Item> items2 = new List<Item>(items);
        items2.RemoveAt(0);
        float worst1 = Worst(row, sideLength);
        float worst2 = Worst(row2, sideLength);
        if (row.Count() == 0 || worst1 > worst2)
            Squarify(items2, row2, sideLength);
        else
        {
            ComputeTreeMaps(row);
            Squarify(items, new List<Item>(), ShortestSide());
        }
    }
    private void ComputeTreeMaps(IEnumerable<Item> items)
    {
        var orientation = this.GetOrientation();
        float areaSum = 0;
        foreach (var item in items)
            areaSum += item.TMData.Area;
        RectangleF currentRow;
        if (orientation == RowOrientation.Horizontal)
        {
            currentRow = new RectangleF(emptyArea.X, emptyArea.Y, areaSum / emptyArea.Height, emptyArea.Height);
            emptyArea = new RectangleF(emptyArea.X + currentRow.Width, emptyArea.Y, Math.Max(0, emptyArea.Width - currentRow.Width), emptyArea.Height);
        }
        else
        {
            currentRow = new RectangleF(emptyArea.X, emptyArea.Y, emptyArea.Width, areaSum / emptyArea.Width);
            emptyArea = new RectangleF(emptyArea.X, emptyArea.Y + currentRow.Height, emptyArea.Width, Math.Max(0, emptyArea.Height - currentRow.Height));
        }
        float prevX = currentRow.X;
        float prevY = currentRow.Y;
        foreach (var item in items)
        {
            var rect = GetRectangle(orientation, item, prevX, prevY, currentRow.Width, currentRow.Height);
            item.TMData.Size = rect.Size;
            item.TMData.Location = rect.Location;
            ComputeNextPosition(orientation, ref prevX, ref prevY, rect.Width, rect.Height);
        }
    }
    private RectangleF GetRectangle(RowOrientation orientation, Item item, float x, float y, float width, float height)
    {
        if (orientation == RowOrientation.Horizontal)
            return new RectangleF(x, y, width, item.TMData.Area / width);
        else
            return new RectangleF(x, y, item.TMData.Area / height, height);
    }
    private void ComputeNextPosition(RowOrientation orientation, ref float xPos, ref float yPos, float width, float height)
    {
        if (orientation == RowOrientation.Horizontal)
            yPos += height;
        else
            xPos += width;
    }
    private RowOrientation GetOrientation()
    {
        return emptyArea.Width > emptyArea.Height ? RowOrientation.Horizontal : RowOrientation.Vertical;
    }
    private float Worst(IEnumerable<Item> row, float sideLength)
    {
        if (row.Count() == 0) return 0;
        float maxArea = 0;
        float minArea = float.MaxValue;
        float totalArea = 0;
        foreach (var item in row)
        {
            maxArea = Math.Max(maxArea, item.TMData.Area);
            minArea = Math.Min(minArea, item.TMData.Area);
            totalArea += item.TMData.Area;
        }
        if (minArea == float.MaxValue) minArea = 0;
        float val1 = (sideLength * sideLength * maxArea) / (totalArea * totalArea);
        float val2 = (totalArea * totalArea) / (sideLength * sideLength * minArea);
        return Math.Max(val1, val2);
    }
    private float ShortestSide()
    {
        return Math.Min(emptyArea.Width, emptyArea.Height);
    }
    private bool IsValidSize(SizeF size)
    {
        return (!size.IsEmpty && size.Width > 0 && size.Width != float.NaN && size.Height > 0 && size.Height != float.NaN);
    }
    private enum RowOrientation
    {
        Horizontal,
        Vertical
    }
