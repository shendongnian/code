      tChart1.Aspect.View3D = false;
    
      var boxSeries1 = new Steema.TeeChart.Styles.Box(tChart1.Chart);
      var boxSeries2 = new Steema.TeeChart.Styles.Box(tChart1.Chart);
      var boxSeries3 = new Steema.TeeChart.Styles.Box(tChart1.Chart);
    
      boxSeries1.Add(DateTime.Now.AddDays(0).ToOADate(), new double[6] { 3, 6, 8, 15, 19, 21 });
      boxSeries2.Add(DateTime.Now.AddDays(1).ToOADate(), new double[4] { 5, 7, 12, 21 });
      boxSeries3.Add(DateTime.Now.AddDays(2).ToOADate(), new double[5] { 6, 7, 8, 15, 21 });
    
      // A simple trick to force custom axis labels on bottom axis.
      // In this case, series titles
      Steema.TeeChart.AxisLabelsItems labels = tChart1.Axes.Bottom.Labels.Items;
      labels.Clear();
    
      foreach (Steema.TeeChart.Styles.Box b in tChart1.Series)
      {
        b.XValues.DateTime = true;
        labels.Add(b.Position);
      }
    
      tChart1.Axes.Bottom.Labels.DateTimeFormat = "dd/MM/yyyy hh:mm";
