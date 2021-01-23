      Steema.TeeChart.Styles.Gantt series = new Steema.TeeChart.Styles.Gantt(tChart1.Chart);
    
      tChart1.Aspect.View3D = false;
    
      for (int i = 0; i < 10; i++)
      {
        series.Add(DateTime.Now.AddDays(i), DateTime.Now.AddDays(i+5), i, "task " + i.ToString());
        series.NextTasks[series.Count - 1] = series.Count;
      }
