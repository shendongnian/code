    void addValuesToLegend(Legend L, Series S, bool addYValues)
    {
        // create a new row for the legend
        LegendItem newItem = new LegendItem();
        // if the sweries has a markerstyle we show it:
        newItem.MarkerStyle = S.MarkerStyle ;
        newItem.MarkerColor = S.Color; 
        newItem.MarkerSize *= 2;   // bump up the size
        if (S.MarkerStyle == MarkerStyle.None)
        {
            // no markerstyle so we just show a colored rectangle
            // you could add code to show a line for other chart types..
            newItem.ImageStyle = LegendImageStyle.Rectangle;
            newItem.Color = S.Color;
        }
        else newItem.ImageStyle =  LegendImageStyle.Marker;
        // we can create horizontal lines
        newItem.BorderWidth = 1;
        newItem.SeparatorColor = Color.DimGray;
        newItem.SeparatorType = LegendSeparatorStyle.Line;
        // but I don't know how to create vertical one!
        // the rowheader shows the maker or the series color
        newItem.Cells.Add(LegendCellType.SeriesSymbol, "", ContentAlignment.MiddleCenter);
        // add series name
        newItem.Cells.Add(LegendCellType.Text, addYValues ? S.Name : "",
                          ContentAlignment.MiddleLeft);
        // combine the 1st two cells:
        newItem.Cells[1].CellSpan = 2;
        // we hide the first cell of the header
        if (!addYValues)
        {
            newItem.ImageStyle = LegendImageStyle.Line;
            newItem.Color = Color.Transparent;
        }
        //
        foreach (DataPoint dp in S.Points)
        {
            // we format the y-value
            string t = dp.YValues[0].ToString(S.Tag.ToString());
            // or maybe the x-value. it is a datatime so we need to convert it!
            // note the escaping to work around my european locale!
            if (!addYValues) t = DateTime.FromOADate(dp.XValue).ToString("M\\/d\\/yyyy");
            newItem.Cells.Add(LegendCellType.Text, t, ContentAlignment.MiddleCenter);
        }
        // we can create some white space around the data:
        foreach (var cell in newItem.Cells)  cell.Margins = new Margins(25, 20, 25, 20);
        // finally add the row of cells:
        L.CustomItems.Add(newItem);
    }
