    void makeSteps(Series S)
    {
        List<DataPoint> points = S.Points.ToList();
        S.Points.Clear();
        for(int i = 0; i < points.Count - 1; i++)
        {
            S.Points.Add(points[i]);
            S.Points.AddXY(points[i + 1].XValue, points[i].YValues[0]);
        }
    }
