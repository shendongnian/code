    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace CPUPerformanceChart
    {
        public partial class Form1 : Form
        {
            private int GridlinesOffset = 0;
    
            public Form1()
            {
                InitializeComponent();
    
                Color axisColor = Color.FromArgb(100, 100, 100);
                Color gridColor = Color.FromArgb(200, 200, 200);
                Color backColor = Color.FromArgb(246, 246, 246);
                Color lineColor = Color.FromArgb(50, 50, 200);
    
                chart.Series[0].Color = lineColor;
    
                chart.ChartAreas[0].BackColor = backColor;
    
                chart.ChartAreas[0].BorderWidth = 1;
                chart.ChartAreas[0].BorderColor = axisColor;
                chart.ChartAreas[0].BorderDashStyle =
                    System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
    
                chart.ChartAreas[0].AxisX.LineColor = axisColor;
                chart.ChartAreas[0].AxisY.LineColor = axisColor;
    
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = gridColor;
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = gridColor;
    
                chart.ChartAreas[0].AxisX.MajorGrid.Interval = 10;
                chart.ChartAreas[0].AxisY.MajorGrid.Interval = 10;
    
                // 60 seconds interval.
                chart.ChartAreas[0].AxisX.Minimum = 0;
                chart.ChartAreas[0].AxisX.Maximum = 60;
    
                chart.ChartAreas[0].AxisY.Minimum = 0;
                chart.ChartAreas[0].AxisY.Maximum = 100;
    
                chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
                chart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
    
                chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
                chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
    
                for (int i = 0; i < 60; i++)
                {
                    chart.Series["Series1"].Points.AddY(0);
                }
            }
    
            // timer.Interval = 1000.
            private void timer_Tick(object sender, EventArgs e)
            {
                float nextValue = cpuPerformanceCounter.NextValue();
    
                labelCpuUsage.Text = String.Format("{0:0.00} %", nextValue);
    
                chart.Series["Series1"].Points.AddY(nextValue);
                chart.Series["Series1"].Points.RemoveAt(0);
    
                // Make gridlines move.
                chart.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
    
                // Calculate next offset.
                GridlinesOffset++;
                GridlinesOffset %= (int) chart.ChartAreas[0].AxisX.MajorGrid.Interval;
            }
        }
    }
