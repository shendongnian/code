    protected void zzz(object sender, EventArgs e)
    {
        foreach (GridViewRow _row in mygrid.Rows)
        {
            if (_row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList hi = (RadioButtonList)_row.FindControl("hi");
                if(hi.SelectedItem != null) //This checks to see if a radio button in the list was selected
                {
                    TextBox txPregoeiro = (TextBox)_row.FindControl("txPregoeiro");
                    txPregoeiro.Text = string.Empty;
                }
            }
        }
    }
