    protected void dgProduct_ItemDataBound(object sender, RepeaterItemEventArgs args) {
        if (args.Row.RowType == DataControlRowType.Header) {
            //Adjust the headerText here
            args.Row.Cells[3].Text = "New header text";
            //Or more elegantly try to avoid doing this by index
        }
    }
