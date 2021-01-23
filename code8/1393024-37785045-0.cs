    chart1.ApplyPaletteColors();  // necessary to access the original colors
    if (checkBox1.Checked)
    {
        foreach (Series s in chart6.Series)
            s.Color = Color.FromArgb(192, s.Color);
    }
