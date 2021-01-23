    protected void ValidateSubject_Click(object sender, EventArgs e)
    {
        CheckBox chk= (CheckBox)sender;
        GridViewRow grvRow = (GridViewRow)chk.NamingContainer;//This will give you row
        grvRow.Cells[10].Text = "Validated"; //Updated the cell text in that row.
        //Or if Status is a control like label then //
        Label StatusLabel = (Label)grvRow.FindControl("StatusLabel");
        StatusLabel.Text = "Validated";
    }
