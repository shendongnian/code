    protected HtmlInputText txtMemPieceType
    {
        get { return findMemPieceType(); }
    }
    
    private HtmlInputText findMemPieceType()
    {
        foreach (GridViewRow row in gvPieceOutturns.Rows)
        {
            if (/* Determine which row has the info you need */)
            {
                return row.FindControl("txtMemPieceType") as HtmlInputText;
            }
        }       
    }
