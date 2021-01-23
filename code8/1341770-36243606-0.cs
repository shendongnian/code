    private Task<PointCollection> ConvertToPointCollection()
    {
        return Task.Run<PointCollection>(() =>
        {
            PointCollection points = new PointCollection();
            points.Add(new System.Windows.Point(0, 6236832));                
            points.Add(new System.Windows.Point(255, 6236832));
            points.Freeze();
            return points;
        });
    }
