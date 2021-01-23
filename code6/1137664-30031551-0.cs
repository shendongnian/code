      tChart1.Aspect.View3D = false;
    
      Steema.TeeChart.Styles.Line line1 = new Steema.TeeChart.Styles.Line(tChart1.Chart);
    
      line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.None;
    
      Random y = new Random();
    
      for (int i = 0; i < 360; i++)
      {
        double tmp = (i + 180) % 360;
        string label = i.ToString();
    
        line1.Add(tmp, y.Next(), label);
      }
