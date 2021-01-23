    foreach (var points in list)
            {
                var pointAnnotation1 = new PointAnnotation();
                pointAnnotation1.X = Convert.ToDouble(points.Key);
                pointAnnotation1.Y = Convert.ToDouble(points.Value);
                pointAnnotation1.Text = String.Format("{0}-{1}",points.Key,points.Value);
                lineseriesobject.Points.Add(new OxyPlot.DataPoint(Convert.ToDouble(points.Key), Convert.ToDouble(points.Value)));
                lineseriesobject.Annotations.Add(pointAnnotation1);
            }
