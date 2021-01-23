    protected void AddHeaders()
    {
        GridViewRow topRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell vesselInfotc = new TableCell();
        vesselInfotc.Text = "Vessel Information ";
        ...
        vesselInfotc.ColumnSpan = 4;
        topRow.Cells.Add(vesselInfotc);
    
        TableCell vesselArrivaltc = new TableCell();
        vesselArrivaltc.Text = "Vessel Arrival ";
        vesselArrivaltc.Style.Add("text-align", "center");
        ...
        vesselArrivaltc.ColumnSpan = 2;
        topRow.Cells.Add(vesselArrivaltc);
    
        this.BerthScoreCardGridView.Controls[0].Controls.AddAt(0, topRow);
    }
