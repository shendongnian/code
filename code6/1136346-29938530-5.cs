    private void button2_Click(object sender, EventArgs e)
    {
        ChartArea CA = chart1.ChartAreas[0];
        CA.AxisY2.Enabled = AxisEnabled.True;
        CA.AxisY.Enabled = AxisEnabled.False;
        CA.AxisX.IsReversed = true;
    }
