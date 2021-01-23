    // In MSChartExtensions.cs
    public static void ChangeTool(this Chart sender, string option)
    {
        if (option == "Zoom")
            SetChartControlState(sender, MSChartExtensionToolState.Zoom);
        else if (option == "Select")
            SetChartControlState(sender, MSChartExtensionToolState.Select);
        else if (option == "Pan")
            SetChartControlState(sender, MSChartExtensionToolState.Pan);
        else if (option == "Zoom Out")
        {
            Chart ptrChart = sender;
            WindowMessagesNativeMethods.SuspendDrawing(ptrChart);
            ptrChart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            ptrChart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            ptrChart.ChartAreas[0].AxisY2.ScaleView.ZoomReset();
            WindowMessagesNativeMethods.ResumeDrawing(ptrChart);
        }
    }
