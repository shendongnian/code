    // e.g. when ocpu text change
    chartcpu.Series["Original"].Points.Clear();
    double yValue = 0;
    if (!String.IsNullOrEmpty(ocpu.Text) && Double.TryParse(ocpu.Text, out yValue))
    {
        chartcpu.Series["Original"].Points.AddXY("CPU", yValue);
    }
