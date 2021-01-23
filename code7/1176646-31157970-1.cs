      tChart1.Dock = DockStyle.Fill;
      tChart1.Aspect.View3D = false;
      tChart1.Legend.Visible = false;
    
      Color[] MyPalette = new Color[15];
      Random random = new Random();
    
      for (int t = 0; t < 15; ++t) MyPalette[t] = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));     
    
      Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(tChart1.Chart, MyPalette);
    
      Steema.TeeChart.Styles.Pie pie1 = new Steema.TeeChart.Styles.Pie(tChart1.Chart);
      pie1.FillSampleValues(10);
      pie1.Marks.Visible = false;
