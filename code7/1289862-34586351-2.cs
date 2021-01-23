    if (line.Contains("ObjectX>"))
    {
        Rectangle r = rectangles.Last();
        r.X = Convert.ToInt32(line.Substring(9));
    }
    if (line.Contains("ObjectY>"))
    {
        Rectangle r = rectangles.Last();
        r.Y = Convert.ToInt32(line.Substring(9));
    }
