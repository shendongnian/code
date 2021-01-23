    protected HtmlInputText txtMemPieceType { get; set; }
    
    void gvPieceOutturns_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = ContactsGridView.Rows[index];
        txtMemPieceType = row.FindControl("txtMemPieceType") as HtmlInputText;
    }
