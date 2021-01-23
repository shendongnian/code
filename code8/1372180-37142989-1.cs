    ChartArea CA1 = chart1.ChartAreas[0];
    ChartArea CA2 = chart1.ChartAreas.Add("ChartArea2");
    // 2nd CA aligns to the 1st one:
    CA2.AlignWithChartArea = "ChartArea1";
    CA2.AlignmentOrientation = AreaAlignmentOrientations.Vertical;
    CA2.AlignmentStyle = AreaAlignmentStyles.AxesView;
    // both have the same range:
    CA1.AxisX.Maximum = 30;
    CA2.AxisX.Maximum = 30;
    CA1.AxisX.Minimum = 0;
    CA2.AxisX.Minimum = 0;
    // both are interactively zoomable:
    CA1.AxisX.ScaleView.Zoomable = true;
    CA1.AxisX.ScrollBar.Enabled = true;
    CA1.CursorX.IsUserSelectionEnabled = true;
    CA2.AxisX.ScaleView.Zoomable = true;
    CA2.AxisX.ScrollBar.Enabled = true;
    CA2.CursorX.IsUserSelectionEnabled = true;
