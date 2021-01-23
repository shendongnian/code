    chart.ChartAreas[0].AxisY.LabelStyle.Format = "IndonesianNumericFormat";
    void chart_FormatNumber(object sender, FormatNumberEventArgs e)
    {
        switch (e.Format)
        {
            case "IndonesianNumericFormat":
                e.LocalizedValue = e.Value.ToString("N2", new CultureInfo("id-ID"));
                break;
        }
    }
