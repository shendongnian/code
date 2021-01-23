    private void Print()
    {
        PrintDialog pdialog = new PrintDialog();
        if (pdialog.ShowDialog() == true)
        {
            // Save current layout
            Transform origTransform = LayoutTransform;
            // Get printer caps
            PrintCapabilities capabilities = pdialog.PrintQueue.GetPrintCapabilities(pdialog.PrintTicket);
            // Calculate zoom level of window
            double ratio = Math.Min(capabilities.PageImageableArea.ExtentWidth / ActualWidth,
                capabilities.PageImageableArea.ExtentHeight / ActualHeight);
            //if (ratio < 1) // Uncomment this line if you dont want zoom out small window
            {
                LayoutTransform = new ScaleTransform(ratio, ratio);
            }
            // Get size of the printer page
            var sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
            Measure(sz);
            Arrange(new Rect(new System.Windows.Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));
            UpdateLayout();
            pdialog.PrintVisual(this, "My Image");
            // Store old layout
            LayoutTransform = origTransform;
        }
    }
