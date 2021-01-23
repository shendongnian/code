    private void cbx_AutoRange_CheckedChanged(object sender, EventArgs e)
    {
        if (cbx_AutoRange.Checked)
        {
            chart.ChartAreas[0].AxisX.Minimum = double.NaN;
            chart.ChartAreas[0].AxisX.Maximum = double.NaN;
            chart.ChartAreas[0].AxisX.Interval = double.NaN;
            chart.ChartAreas[0].AxisY.Minimum = double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = double.NaN;
            numUD_Graph_Xmin.Enabled = false;
            numUD_Graph_Xmax.Enabled = false;
            numUD_Graph_XInterval.Enabled = false;
            numUD_Graph_Ymin.Enabled = false;
            numUD_Graph_Ymax.Enabled = false;
            
        }
        else
        {
            numUD_Graph_Xmin.Enabled = true;
            numUD_Graph_Xmin.Value = (decimal)chart1.Series[0].Points.FindMinByValue().XValue;
            numUD_Graph_Xmax.Value = (decimal)chart1.Series[0].Points.FindMaxByValue().XValue;
          //.. etc
          //.. etc
        }
    }
