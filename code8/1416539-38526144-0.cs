    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList rbl = sender as RadioButtonList;
        string answer = rbl.SelectedValue;
        HiddenField hiddenQuestionID = rbl.NamingContainer.FindControl("hiddenQuestionID") as HiddenField;
        string questionID = hiddenQuestionID.Value;
        ...
    }
