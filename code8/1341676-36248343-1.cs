        // chartarea pixel size:
        Size CaSize = new Size( (int)( cap.Width * chart1.ClientSize.Width / 100f), 
                                (int)( cap.Height * chart1.ClientSize.Height / 100f));
        // InnerPlotArea pixel size:
       Size IppSize = new Size((int)(cip.Width * CaSize.Width / 100f),
                                (int)(cip.Height * CaSize.Height / 100f));
