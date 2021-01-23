    // Interpolate the image using the calculated weights.
    // First process the columns.
    Parallel.For(
        0,
        sourceBottom,
        y =>
        {
            for (int x = startX; x < endX; x++)
            {
                Weight[] horizontalValues = this.HorizontalWeights[x].Values;
                // Destination color components
                Color destination = new Color();
                foreach (Weight xw in horizontalValues)
                {
                    int originX = xw.Index;
                    Color sourceColor = Color.Expand(source[originX, y]);
                    destination += sourceColor * xw.Value;
                }
                destination = Color.Compress(destination);
                this.firstPass[x, y] = destination;
            }
        });
    // Now process the rows.
    Parallel.For(
        startY,
        endY,
        y =>
        {
            if (y >= targetY && y < targetBottom)
            {
                Weight[] verticalValues = this.VerticalWeights[y].Values;
                for (int x = startX; x < endX; x++)
                {
                    // Destination color components
                    Color destination = new Color();
                    foreach (Weight yw in verticalValues)
                    {
                        int originY = yw.Index;
                        int originX = x;
                        Color sourceColor = Color.Expand(this.firstPass[originX, originY]);
                        destination += sourceColor * yw.Value;
                    }
                    destination = Color.Compress(destination);
                    target[x, y] = destination;
                }
            }
        });
