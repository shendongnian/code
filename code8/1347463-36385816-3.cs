    protected void AddHeaders()
    {
        GridViewRow topHeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell vesselInfotc = new TableCell();
        vesselInfotc.Text = "Vessel Information ";
        ...
        vesselInfotc.ColumnSpan = 4;
        topHeaderRow.Cells.Add(vesselInfotc);
    
        TableCell vesselArrivaltc = new TableCell();
        vesselArrivaltc.Text = "Vessel Arrival ";
        ...
        vesselArrivaltc.ColumnSpan = 2;
        topHeaderRow.Cells.Add(vesselArrivaltc);
        // Add the other cells here
        ...
        BerthScoreCardGridView.Controls[0].Controls.AddAt(0, topHeaderRow);
    }
