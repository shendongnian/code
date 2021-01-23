    public partial class formMain : Form
        {
            int usage;
            int x = 1;
            protected PerformanceCounter countCpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    
            public formMain()
            {
                InitializeComponent();
    
                timerMain.Tick += new EventHandler(timerMain_Tick);
                timerMain.Start();
            }
    
            private void timerMain_Tick(object sender, EventArgs e)
            {
                usage = Convert.ToInt32(countCpu.NextValue());
                chartCpu.Series["CPU"].Points.AddXY(x, usage);
                lblCpu.Text = Convert.ToString(usage.ToString()) + "%";
                x++;
    
                if(chartCpu.ChartAreas[0].AxisX.Maximum > chartCpu.ChartAreas[0].AxisX.ScaleView.Size)
                {
                    chartCpu.ChartAreas[0].AxisX.ScaleView.Scroll(chartCpu.ChartAreas[0].AxisX.Maximum);
                }
            }
        }
