    protected void Checkboxes_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkBox = (CheckBox)sender;
        var chkBoxID = chkBox.ID;
        Label chkBoxLabel = (Label)FindControl(chkBoxID + "Label");
        if(chkBox.Checked == true)
        {
            chkBoxLabel.Text = "checked";
        }
        if(chkBox.Checked == false)
        {
            chkBoxLabel.Text = "";
        }
    }
