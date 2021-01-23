    protected void Chart1_Customize(object sender, EventArgs e)
    {
        foreach (var label in Chart1.ChartAreas[0].AxisY.CustomLabels)
        {
            int secondsAmount = int.Parse(label.Text);
            string timeString = "";
            // Insert the conversion logic here and get the timeString...
            label.Text = timeString. // format DD:HH:MM:SS
        }
    }
