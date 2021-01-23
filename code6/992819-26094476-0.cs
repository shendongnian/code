    private void chart_MouseDown(object sender, MouseEventArgs e)
    {
        HitTestResult result = chart.HitTest(e.X, e.Y);
        if (result.ChartElementType == ChartElementType.DataPoint)
        {
            var selectedValue = chart.Series[0].Points[result.PointIndex].YValues[0];
            MessageBox.Show(selectedValue.ToString());
        }
          
    }
