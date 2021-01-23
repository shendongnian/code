    foreach (var points in list)
    {
      var pointAnnotation = new PointAnnotation()
      {
        X = Convert.ToDouble(points.Key),
        Y = Convert.ToDouble(points.Value),
        Text = String.Format("{0}-{1}",points.Key,points.Value)
      });
      lineSeriesObject.Points.Add(new OxyPlot.DataPoint(Convert.ToDouble(points.Key), Convert.ToDouble(points.Value)));
      plotModelObject.Annotations.Add(pointAnnotation);
    }
    plotModelObject.Series.Add(lineSeriesObject);
