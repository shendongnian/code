     var model = new PlotModel("Broken line");
     
     var s1 = new LineSeries
         {
             // If you want to style
             //BrokenLineColor = OxyColors.Gray,
             //BrokenLineThickness = 1,
             //BrokenLineStyle = LineStyle.Dash
             BrokenLineStyle = LineStyle.None
         };
     s1.Points.Add(new DataPoint(0, 26));
     s1.Points.Add(new DataPoint(10, 30));
     s1.Points.Add(DataPoint.Undefined);
     s1.Points.Add(new DataPoint(10, 25));
     s1.Points.Add(new DataPoint(20, 26));
     s1.Points.Add(new DataPoint(25, 36));
     s1.Points.Add(new DataPoint(30, 40));
     s1.Points.Add(DataPoint.Undefined);
     s1.Points.Add(new DataPoint(30, 20));
     s1.Points.Add(new DataPoint(40, 10));
     model.Series.Add(s1);
