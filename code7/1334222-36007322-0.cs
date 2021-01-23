    public Form1()
    {
      InitializeComponent();
      InitializeChart();
    }
    
    private Steema.TeeChart.Styles.FastLine fastLine1;
    
    private void InitializeChart()
    {
      tChart1.Aspect.View3D = false;
      tChart1.MouseMove += new MouseEventHandler(tChart1_MouseMove);
    
      fastLine1 = new Steema.TeeChart.Styles.FastLine(tChart1.Chart);
      fastLine1.FillSampleValues();
      fastLine1.MouseEnter += new EventHandler(fastLine1_MouseEnter);
    }
    
    private int x, y;
    
    void tChart1_MouseMove(object sender, MouseEventArgs e)
    {
      x = e.X;
      y = e.Y;
    }
    
    void fastLine1_MouseEnter(object sender, EventArgs e)
    {
      int index = fastLine1.Clicked(x, y);
    
      if (index != -1)
      {
        tChart1.Header.Text = index.ToString();
      }
    }
