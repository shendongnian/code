    CA.AxisY.Minimum = 0;
    CA.AxisY.Maximum = 4;
    int old = 3;
    for (int i = 0; i < 5; i++ )
    {
        CustomLabel cl = new CustomLabel(i - 0.5d, i + 0.5d, 
                    i < old ? i + "" : i == old ? "old" : "too old", 0, LabelMarkStyle.None);
        CA.AxisY.CustomLabels.Add(cl);
    }
