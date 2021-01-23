    void makeSquare(Chart chart)
    {
        ChartArea ca = chart.ChartAreas[0];
        // store the original value:
        if (ipp0 == null) ipp0 = ca.InnerPlotPosition;
        // get the current chart area :
        ElementPosition cap = ca.Position;
        // get both area sizes in pixels:
        Size CaSize = new Size( (int)( cap.Width * chart1.ClientSize.Width / 100f), 
                                (int)( cap.Height * chart1.ClientSize.Height / 100f));
        Size IppSize = new Size((int)(ipp0.Width * CaSize.Width / 100f),
                                (int)(ipp0.Height * CaSize.Height / 100f));
        // we need to use the smaller side:
        int ippNewSide = Math.Min(IppSize.Width, IppSize.Height);
        // calculate the scaling factors
        float px = ipp0.Width / IppSize.Width * ippNewSide;
        float py = ipp0.Height / IppSize.Height * ippNewSide;
        // use one or the other:
        if (IppSize.Width  < IppSize.Height)
            ca.InnerPlotPosition = new ElementPosition(ipp0.X, ipp0.Y, ipp0.Width, py);
        else 
            ca.InnerPlotPosition = new ElementPosition(ipp0.X, ipp0.Y, px, ipp0.Height);
    }
