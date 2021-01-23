    private void Print()
    {
        PrintDialog pdialog = new PrintDialog();
        if (pdialog.ShowDialog() == true)
        {
            // Save current layout
            Transform origTransform = LayoutTransform;
            Size oldWindowSize = new Size(ActualWidth, ActualHeight);
            // Get printer caps
            PrintCapabilities capabilities = pdialog.PrintQueue.GetPrintCapabilities(pdialog.PrintTicket);
            // Get size of the printer page
            var sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
            // Calculate zoom level of window
            double ratio = Math.Min(sz.Width / ActualWidth, sz.Height / ActualHeight);
            //if (ratio < 1) // Uncomment this line if you dont want zoom out small window
            {
                LayoutTransform = new ScaleTransform(ratio, ratio);
            }
            Measure(sz);
            Arrange(new Rect(new Point(0,0), sz));
            pdialog.PrintVisual(this, "My Image");
            // Store old layout
            LayoutTransform = origTransform;
            Measure(oldWindowSize);
            Arrange(new Rect(new Point(0, 0), oldWindowSize));
        }
    }
