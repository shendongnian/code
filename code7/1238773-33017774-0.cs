    public Form1()
    {
      InitializeComponent();
      InitializeChart();
    }
    
    private void InitializeChart()
    {
      tChart1.Aspect.View3D = false;
    
      tChart1.Series.Add(new Steema.TeeChart.Styles.Line()).FillSampleValues();
      tChart1.MouseMove += TChart1_MouseMove;
    }
    
    private void TChart1_MouseMove(object sender, MouseEventArgs e)
    {
      var nearestPoint = new Steema.TeeChart.Tools.NearestPoint(tChart1[0]);
      nearestPoint.Active = false;
      var p = new Point(e.X, e.Y);
      var index = nearestPoint.GetNearestPoint(p);
    
      if (index != -1)
      {
        const int tolerance = 10;
        var px = tChart1[0].CalcXPos(index);
        var py = tChart1[0].CalcYPos(index);
    
        var index2 = (index == tChart1[0].Count - 1) ? index - 1 : index + 1;
        var qx = tChart1[0].CalcXPos(index2);
        var qy = tChart1[0].CalcYPos(index2);
    
        if (Steema.TeeChart.Drawing.Graphics3D.PointInLineTolerance(p, px, py, qx, qy, tolerance))
        {
          tChart1.Header.Text = "point " + index.ToString() + " clicked";
        }
        else
        {
          tChart1.Header.Text = "No point";
        } 
      }
