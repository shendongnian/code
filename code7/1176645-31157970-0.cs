      tChart1.Dock = DockStyle.Fill;
      tChart1.Aspect.View3D = false;
      tChart1.Legend.Visible = false;
    
      Color[] RedPalette = new Color[15];
      for (int t = 0; t < 15; ++t) RedPalette[t] = Color.FromArgb(128 + Convert.ToInt32(Math.Round(t * (128.0 / 15.0))), 0, 0);
    
      Steema.TeeChart.Themes.ColorPalettes.ApplyPalette(tChart1.Chart, RedPalette);
    
      Steema.TeeChart.Styles.Pie pie1 = new Steema.TeeChart.Styles.Pie(tChart1.Chart);
      pie1.FillSampleValues(10);
      pie1.Marks.Visible = false;
