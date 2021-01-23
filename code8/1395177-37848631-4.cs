    private void btn_AutoSize_Click(object sender, EventArgs e)
    {
        chart.ChartAreas[0].AxisX.Minimum = double.NaN;  /// <-- this is the magic 'number'
        chart.ChartAreas[0].AxisX.Maximum = double.NaN;
        chart.ChartAreas[0].AxisY.Minimum = double.NaN;
        chart.ChartAreas[0].AxisY.Maximum = double.NaN;
     // not quite sure about these lines
     /*  
        chart.ChartAreas[0].RecalculateAxesScale();  
        chart.Update();
        updateUI();
     */
    }
