    private void chart1_AxisViewChanged(object sender, ViewEventArgs e)
    {
        setLegendPosition();
    }
    private void chart1_Resize(object sender, EventArgs e)
    {
        setLegendPosition();
    }
    private void setLegendPosition()
    {
        Legend L1 = chart1.Legends[legendOneNameOrIndex];
        Legend L2 = chart1.Legends[legendTwoNameOrIndex];
        L2.Position = new ElementPosition(L1.Position.X, L1.Position.Y + L1.Position.Height, 
                                          L1.Position.Width, L1.Position.Height);
    }
