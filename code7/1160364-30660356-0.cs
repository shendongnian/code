    private void drawLInes()
    {
        drawLines(
            new int[] { 0, 334, 100, 100 },
            new int[] { 0, 334, 200, 200 },
            new int[] { 112, 112, 300, 0 }
            // ...
            );
    }
    private void drawLines(params int[][] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            Line line = new Line();
            Grid myGrid = gg;
            line.Stroke = Brushes.Black;
            line.X1 = lines[i][0];
            line.X2 = lines[i][1];
            line.Y1 = lines[i][2];
            line.Y2 = lines[i][3];
            line.StrokeThickness = 2;
            myGrid.Children.Add(line);
        }
    }
