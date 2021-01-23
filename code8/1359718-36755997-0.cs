    private void Form1_Load(object sender, EventArgs e)
    {
        //Set Chart Margins
        this.chart1.ChartAreas[0].Position.Auto = false;
        this.chart1.ChartAreas[0].Position.X = 10;
        this.chart1.ChartAreas[0].Position.Y = 10;
        this.chart1.ChartAreas[0].Position.Width = 80;
        this.chart1.ChartAreas[0].Position.Height = 80;
        //Configure X Axis
        this.chart1.ChartAreas[0].AxisX.Crossing = 0;
        this.chart1.ChartAreas[0].AxisX.Interval = 1;
        this.chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
        this.chart1.ChartAreas[0].AxisX.LineWidth = 2;
        this.chart1.ChartAreas[0].AxisX.ArrowStyle =
            System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
        //Configure Y Axis
        this.chart1.ChartAreas[0].AxisY.Crossing = 0;
        this.chart1.ChartAreas[0].AxisY.Interval = 5;
        this.chart1.ChartAreas[0].AxisY.LineWidth = 2;
        this.chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
        this.chart1.ChartAreas[0].AxisY.ArrowStyle =
            System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
        //Set Chart Type
        this.chart1.Series[0].ChartType = 
            System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        //Set Data
        var p = new List<PointF>();
        for (int i = -5; i <= 5; i++)
        {
            p.Add(new PointF(i, i * Math.Abs(i)));
        }
        this.chart1.DataSource = p;
        this.chart1.Series[0].XValueMember = "X";
        this.chart1.Series[0].YValueMembers = "Y";
        this.chart1.Series[0].IsVisibleInLegend = false;
    }
