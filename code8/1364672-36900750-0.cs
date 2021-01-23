    private void RunMeshButton_Click(object sender, RoutedEventArgs e)
    {
        TrizieartMesher mesher = new TrizieartMesher(new Rect(MainImage.RenderSize));
        EdgeCountText.Text = $"{mesher.Edges.Count()}";
        MainCanvas.Children.Clear();
        List<Line> meshLines = mesher.Edges.Select(edge => CreateLine(edge.P1, edge.P2)).ToList();
        foreach (Line line in meshLines)
        {
            MainCanvas.Children.Add(line);
        }
    }
    private static Line CreateLine(Point p1, Point p2)
    {
        Line newLine = new Line();
        newLine.X1 = p1.X;
        newLine.Y1 = p1.Y;
        newLine.X2 = p2.X;
        newLine.Y2 = p2.Y;
        newLine.Stroke = Brushes.MediumOrchid;
        return newLine;
    }
