    protected void GrvTicketList_DataBound(Object sender, EventArgs e)
    {
        GridView grid = (GridView)sender;
        grid.Columns[9].Visible = IsExpert || IsAgent;
    }
