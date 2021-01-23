    private int? _NumDecimals;
    private int NumDecimals 
    {
        get 
        {
            if (!_NumDecimals.HasValue)
                _NumDecimals = GetNumDecimalsFromDB();
            return _NumDecimals.Value;
        }
        set 
        {
            _NumDecimals = value;
        }
    }
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // if following doesnt work use the debugger to see the type of e.Row.DataItem
            DataRow row = ((DataRowView)e.Row.DataItem).Row;
            int numFailedFiles = row.Field<int>("NumFailedFiles");
            //presuming that your TemplateField contains a Label with ID="LblNumFailedFiles"
            Label LblNumFailedFiles = (Label)e.Row.FindControl("LblNumFailedFiles");
            string formatString = String.Format("N{0}", NumDecimals);
            LblNumFailedFiles.Text = numFailedFiles.ToString(formatString);
        }
    }
