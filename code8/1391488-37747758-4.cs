    // we want to show a secondary axis on top:
    ca2.AxisX2.Enabled = AxisEnabled.True;
    // don't disable the primary axis if you want any labels!
    // instead make its labels transparent!
    ca2.AxisX.LabelStyle.ForeColor = Color.Transparent;
    // this is shared by the sec.axis event though it has its own property!
    ca2.AxisX.LabelStyle.Interval = 10;
    // I color the axis and the labels
    ca2.AxisX2.LineColor = S22.Color;
    ca2.AxisX2.LabelStyle.ForeColor = S22.Color;
    // we need to set the range for both (!) axes:
    ca2.AxisX2.Minimum = 100;
    ca2.AxisX2.Maximum = 200;
    ca2.AxisX.Minimum = 100;
    ca2.AxisX.Maximum = 200;
