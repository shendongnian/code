    private readonly CultureInfo indonesiaCulture = CultureInfo.GetCultureInfo("id-ID");
    void chart1_FormatNumber(object sender, FormatNumberEventArgs e)
    {
        if (e.ElementType == ChartElementType.AxisLabels)
        {
            e.LocalizedValue = e.Value.ToString("N2", indonesiaCulture);
        }
    }
