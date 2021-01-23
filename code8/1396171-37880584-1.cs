    private void Form1_Load(object sender, EventArgs e)
    {
        chartControl1.CrosshairEnabled = DefaultBoolean.False;
        chartControl1.RuntimeHitTesting = true;
    }
    private void chartControl1_MouseClick(object sender, MouseEventArgs e)
    {
        // Obtain hit information under the test point.
        ChartHitInfo hi = chartControl1.CalcHitInfo(e.X, e.Y);
    
        // Obtain the series point under the test point.
        SeriesPoint point = hi.SeriesPoint;
    
        // Check whether the series point was clicked or not.
        if (point != null)
        {
            // Obtain the series point argument.
            string argument = "Argument: " + point.Argument.ToString();
    
            // Obtain series point values.
            string values = "Value(s): " + point.Values[0].ToString();
            if (point.Values.Length > 1)
            {
                for (int i = 1; i < point.Values.Length; i++)
                {
                    values = values + ", " + point.Values[i].ToString();
                }
            }
    
            MessageBox.Show(argument + "\n" + values, "SeriesPoint Data");
        }
    }
