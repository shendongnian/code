            Graph.Chart chart;
        double MaxY2;
        double MinY2;
        
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(750, 750);
            // Create new Graph
            chart = new Graph.Chart();
            // Define size and chart model
            chart.Location = new System.Drawing.Point(10, 10);
            chart.Size = new System.Drawing.Size(700, 700);
            chart.BackGradientStyle = Graph.GradientStyle.LeftRight;
            chart.BorderSkin.SkinStyle = Graph.BorderSkinStyle.Emboss;
            // Add a chartarea called "draw", add axes to it and color the area black
            chart.ChartAreas.Add("draw");
            
            // Define X axis interval type (seconds). Width 200s, interval = 10s, label every 30s
            chart.ChartAreas["draw"].AxisX.IntervalType = Graph.DateTimeIntervalType.Seconds;
            chart.ChartAreas["draw"].AxisX.Interval = 10;   // Add a tick every 10s interval on X axis (careful, it's different from the grid !!!)
            chart.ChartAreas["draw"].AxisX.Title = "Time (s)";
            chart.ChartAreas["draw"].AxisX.IntervalOffsetType = Graph.DateTimeIntervalType.Seconds;
            chart.ChartAreas["draw"].AxisX.LabelStyle.IntervalType = Graph.DateTimeIntervalType.Seconds;
            chart.ChartAreas["draw"].AxisX.LabelStyle.IntervalOffsetType = Graph.DateTimeIntervalType.Seconds;
            chart.ChartAreas["draw"].AxisX.LabelStyle.Interval = 30;    // Add a label every 30s
            chart.ChartAreas["draw"].AxisX.LabelStyle.IntervalOffset = 0D;
            chart.ChartAreas["draw"].AxisX.LabelStyle.Format = "H:mm:ss";
            chart.ChartAreas["draw"].AxisX.Minimum = 0; // X axis unit is a day ! (don't know why )
            chart.ChartAreas["draw"].AxisX.Maximum = 200.0/(24.0*60.0*60.0); // Unit is a day so convert second in day unit =>  200s => 200s / (24h*60m*60s)
            
            // X Axis grid definition. Interval every 10s, dash line
            chart.ChartAreas["draw"].AxisX.MajorGrid.Interval = 10;   // 10s between each tick (grid cross X axis vertically)
            chart.ChartAreas["draw"].AxisX.MajorGrid.IntervalType = Graph.DateTimeIntervalType.Seconds;
            chart.ChartAreas["draw"].AxisX.MajorGrid.IntervalOffset = 0D;
            chart.ChartAreas["draw"].AxisX.MajorGrid.IntervalOffsetType = Graph.DateTimeIntervalType.Seconds;
            chart.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            // Y axis definition (number). Min = -0.4 Max = 1 Interval = 0.2
            chart.ChartAreas["draw"].AxisY.Minimum = -0.4;
            chart.ChartAreas["draw"].AxisY.Maximum = 1;
            chart.ChartAreas["draw"].AxisY.Interval = 0.2;
            chart.ChartAreas["draw"].AxisY.LabelStyle.IntervalType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY.LabelStyle.IntervalOffsetType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY.LabelStyle.IntervalOffset = 0D;
            chart.ChartAreas["draw"].AxisY.LabelStyle.Interval = 0.1;    // Add a label every 0.1
            chart.ChartAreas["draw"].AxisY.LabelStyle.Format = ".000";
            // Secondary Y axis definition (number). Min = -2 Max = 10 Interval = 0.5
            chart.ChartAreas["draw"].AxisY2.Minimum = -2;
            chart.ChartAreas["draw"].AxisY2.Maximum = 10;
            chart.ChartAreas["draw"].AxisY2.Interval = 0.5;
            chart.ChartAreas["draw"].AxisY2.LabelStyle.IntervalType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY2.LabelStyle.IntervalOffsetType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY2.LabelStyle.IntervalOffset = 0D;
            chart.ChartAreas["draw"].AxisY2.LabelStyle.Interval = 0.5;    // Add a label every 0.5
            chart.ChartAreas["draw"].AxisY2.LabelStyle.Format = ".000";
            // Y Axis grid definition. Interval every 0.1, dash line
            chart.ChartAreas["draw"].AxisY.MajorGrid.Interval = 0.1;   // 0.1 between each tick (grid cross Y axis horizontaly)
            chart.ChartAreas["draw"].AxisY.MajorGrid.IntervalType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY.MajorGrid.IntervalOffset = 0D;
            chart.ChartAreas["draw"].AxisY.MajorGrid.IntervalOffsetType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            // Secondary Y Axis grid definition. Dot line
            chart.ChartAreas["draw"].AxisY2.MajorGrid.LineColor = Color.BurlyWood;
            chart.ChartAreas["draw"].AxisY2.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dot;
            
            // Chart Area back ground color
            chart.ChartAreas["draw"].BackColor = Color.Black;
            // Create two new functions series
            chart.Series.Add("MyFunc");
            chart.Series.Add("MyFunc2");
            // Set the type to line      
            chart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;
            chart.Series["MyFunc2"].ChartType = Graph.SeriesChartType.Line;
            
            // Value tooltip on each series
            chart.Series["MyFunc"].ToolTip = "#VAL";
            chart.Series["MyFunc2"].ToolTip = "#VAL";
            // Color the line of the graph light green and give it a thickness of 3
            chart.Series["MyFunc"].Color = Color.LightGreen;
            chart.Series["MyFunc"].BorderWidth = 3;
            chart.Series["MyFunc2"].Color = Color.Bisque;
            chart.Series["MyFunc2"].BorderWidth = 3;
            // Data type definition for the two series (define X and Y axis for each series)
            chart.Series["MyFunc"].XValueType = Graph.ChartValueType.DateTime;
            chart.Series["MyFunc"].YValueType = Graph.ChartValueType.Double;
            chart.Series["MyFunc"].XAxisType = Graph.AxisType.Primary;
            chart.Series["MyFunc"].YAxisType = Graph.AxisType.Primary;
            chart.Series["MyFunc2"].XValueType = Graph.ChartValueType.DateTime;
            chart.Series["MyFunc2"].YValueType = Graph.ChartValueType.Double;
            chart.Series["MyFunc2"].XAxisType = Graph.AxisType.Primary;
            chart.Series["MyFunc2"].YAxisType = Graph.AxisType.Secondary;
            
            //This function cannot include zero, and we walk through it in steps of 0.1 to add coordinates to our series
            DateTime dto;
            dto = new DateTime();
            for (double x = 0.1; x < 20; x += 0.1)
            {
                chart.Series["MyFunc"].Points.AddXY(dto, Math.Sin(x) / x);
                chart.Series["MyFunc2"].Points.AddXY(dto, Math.Cos(x) / x);
                dto = dto.AddSeconds(1);
            }
            // Add legend to the chart area
            chart.Series["MyFunc"].LegendText = "sin(x) / x";
            chart.Series["MyFunc2"].LegendText = "cos(x) / x";
            // Create a new legend called "MyLegend".
            chart.Legends.Add("MyLegend");
            chart.Legends["MyLegend"].BorderColor = Color.Tomato; // I like tomato juice!
            // Zoom allowed for X and Y axis (done manualy on secondary Y axis)
            chart.ChartAreas["draw"].AxisY.ScaleView.Zoomable = true;
            chart.ChartAreas["draw"].AxisY2.ScaleView.Zoomable = true;
            chart.ChartAreas["draw"].AxisX.ScaleView.Zoomable = true;
            
            // X and Y axis cursor definition. 
            chart.ChartAreas["draw"].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas["draw"].CursorX.IntervalOffsetType = Graph.DateTimeIntervalType.Milliseconds;
            chart.ChartAreas["draw"].CursorX.IntervalType = Graph.DateTimeIntervalType.Milliseconds;
            chart.ChartAreas["draw"].CursorX.IsUserEnabled = true;
            chart.ChartAreas["draw"].CursorY.IsUserEnabled = true;
            chart.ChartAreas["draw"].CursorY.IntervalOffsetType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].CursorY.IntervalType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].CursorY.IsUserSelectionEnabled = true;
            chart.ChartAreas["draw"].CursorY.Interval = 0.001D;  // Minimum value for zooming
            // Définition des mises à l'échelles et des barres de défilements axe X et Y
            chart.ChartAreas["draw"].AxisX.ScaleView.MinSize = 0D;
            chart.ChartAreas["draw"].AxisX.ScaleView.MinSizeType = Graph.DateTimeIntervalType.Milliseconds;
            chart.ChartAreas["draw"].AxisX.ScaleView.SizeType = Graph.DateTimeIntervalType.Milliseconds;
            chart.ChartAreas["draw"].AxisX.ScaleView.SmallScrollMinSize = 0D;
            chart.ChartAreas["draw"].AxisX.ScaleView.SmallScrollMinSizeType = Graph.DateTimeIntervalType.Milliseconds;
            chart.ChartAreas["draw"].AxisX.ScaleView.SmallScrollSizeType = Graph.DateTimeIntervalType.Milliseconds;
            
            chart.ChartAreas["draw"].AxisY.ScaleView.MinSize = 0.1D;
            chart.ChartAreas["draw"].AxisY.ScaleView.MinSizeType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY.ScaleView.SizeType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY.ScaleView.SmallScrollMinSize = 0.001D;
            chart.ChartAreas["draw"].AxisY.ScaleView.SmallScrollMinSizeType = Graph.DateTimeIntervalType.Number;
            chart.ChartAreas["draw"].AxisY.ScaleView.SmallScrollSizeType = Graph.DateTimeIntervalType.Number;
            
            // Scrollbar color definition
            chart.ChartAreas["draw"].AxisX.ScrollBar.BackColor = Color.AliceBlue;
            chart.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightBlue;
            chart.ChartAreas["draw"].AxisY.ScrollBar.BackColor = Color.AliceBlue;
            chart.ChartAreas["draw"].AxisY.ScrollBar.ButtonColor = Color.LightBlue;
            
            // Add the chart to the form (to display it)
            Controls.Add(this.chart);
            // For save and use in AxisViewChanged event
            MaxY2 = chart.ChartAreas["draw"].AxisY2.Maximum;
            MinY2 = chart.ChartAreas["draw"].AxisY2.Minimum;
            // Add event handler on axis view changed (to automatically scroll Y and Y2 axis)
            chart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(chart_AxisViewChanged);
        }
        private void chart_AxisViewChanged(object sender, Graph.ViewEventArgs e)
        {
            // AxisY.ScaleView.ViewMinimum is the minimum Y axis value displayed. It contains the offset to apply to label, grid and interval on Y axis
            chart.ChartAreas["draw"].AxisY.LabelStyle.IntervalOffset = (chart.ChartAreas["draw"].AxisY.LabelStyle.Interval - chart.ChartAreas["draw"].AxisY.ScaleView.ViewMinimum) % chart.ChartAreas["draw"].AxisY.LabelStyle.Interval;
            chart.ChartAreas["draw"].AxisY.MajorGrid.IntervalOffset = (chart.ChartAreas["draw"].AxisY.MajorGrid.Interval - chart.ChartAreas["draw"].AxisY.ScaleView.ViewMinimum) % chart.ChartAreas["draw"].AxisY.MajorGrid.Interval;
            chart.ChartAreas["draw"].AxisY.IntervalOffset = (chart.ChartAreas["draw"].AxisY.Interval - chart.ChartAreas["draw"].AxisY.ScaleView.ViewMinimum) % chart.ChartAreas["draw"].AxisY.Interval;
            
            // To compute zoom percent to apply on secondary Y axis :
            // zoomPercent = (Max - Min displayed values) / ( Max - Min Y axis values)
            double zoomPercent = (chart.ChartAreas["draw"].AxisY.ScaleView.ViewMaximum - chart.ChartAreas["draw"].AxisY.ScaleView.ViewMinimum) / 
                                 (chart.ChartAreas["draw"].AxisY.Maximum - chart.ChartAreas["draw"].AxisY.Minimum);
            // To compute the position in percent on Y axis
            // posPercent = (Min displayed value - Min value) / ( Max - Min Y axis values)
            double posPercent = (chart.ChartAreas["draw"].AxisY.ScaleView.ViewMinimum - chart.ChartAreas["draw"].AxisY.Minimum) / (chart.ChartAreas["draw"].AxisY.Maximum - chart.ChartAreas["draw"].AxisY.Minimum);
            // To compute max and min secondary axis value regarding posPercent and zoomPercent
            // We need to have the original Max and Min value for secondary Y axis. This should be saved somewhere (MaxY2 and MinY2 here).
            chart.ChartAreas["draw"].AxisY2.Minimum = (posPercent * (MaxY2 - MinY2)) + MinY2;
            chart.ChartAreas["draw"].AxisY2.Maximum = (zoomPercent * (MaxY2 - MinY2)) + chart.ChartAreas["draw"].AxisY2.Minimum;
            // To update secondary Y axis label, major grid and interval. (same method as for Y axis above)
            chart.ChartAreas["draw"].AxisY2.LabelStyle.IntervalOffset = (chart.ChartAreas["draw"].AxisY2.LabelStyle.Interval - chart.ChartAreas["draw"].AxisY2.Minimum) % chart.ChartAreas["draw"].AxisY2.LabelStyle.Interval;
            chart.ChartAreas["draw"].AxisY2.MajorGrid.IntervalOffset = (chart.ChartAreas["draw"].AxisY2.MajorGrid.Interval - chart.ChartAreas["draw"].AxisY2.Minimum) % chart.ChartAreas["draw"].AxisY2.MajorGrid.Interval;
            chart.ChartAreas["draw"].AxisY2.IntervalOffset = (chart.ChartAreas["draw"].AxisY2.Interval - chart.ChartAreas["draw"].AxisY2.Minimum) % chart.ChartAreas["draw"].AxisY2.Interval;
        }
