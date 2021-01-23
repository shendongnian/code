        private void bGraph_Click(object sender, RoutedEventArgs e)
        {
            var style = new Style(typeof(Polyline));
            style.Setters.Add(new Setter(Polyline.StrokeProperty, Brushes.Red));
            style.Setters.Add(new Setter(Polyline.StrokeThicknessProperty, 5.0));
            ((LineSeries) lineChart.Series[0]).PolylineStyle = style;
            ((LineSeries) lineChart.Series[1]).PolylineStyle = style;
            ((LineSeries) lineChart.Series[2]).PolylineStyle = style;
        }
