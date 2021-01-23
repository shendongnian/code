    private void chartBind()
    {
        Series ser = Chart2.Series["Series1"];
        ser.Points.AddXY(lblTotalDays.Text, lblPercentage.Text);
    }
