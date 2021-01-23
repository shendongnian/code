    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!e.Button.HasFlag(MouseButtons.Left)) return;
        Axis ax = chart1.ChartAreas[0].AxisX;
        double range = ax.Maximum - ax.Minimum;
        double xv = ax.PixelPositionToValue(e.Location.X);
        ax.Minimum -= xv - mDown;
        ax.Maximum = ax.Minimum + range;
    }
