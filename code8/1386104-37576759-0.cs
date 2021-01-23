        // align the controls:
        yourChart1.Left = yourChart2.Left;
        yourChart1.Size = yourChart2.Size;
        // get the numbers of the current innerplotpositions
        RectangleF ri1 = yourChart1.ChartAreas[0].InnerPlotPosition.ToRectangleF();
        RectangleF ri2 = yourChart2.ChartAreas[0].InnerPlotPosition.ToRectangleF();
        if (ri1.Width < ri2.Width)
        {
            yourChart2.ChartAreas[0].InnerPlotPosition =
                new ElementPosition(ri1.Left, ri2.Top, ri1.Width, ri2.Height);
        }
        else 
        {
            yourChart1.ChartAreas[0].InnerPlotPosition =
                new ElementPosition(ri2.Left, ri1.Top, ri2.Width, ri1.Height);
        }
