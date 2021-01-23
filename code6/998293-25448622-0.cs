    protected void radID_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        if (checkbox.Checked)
        {
            ViewState[checkbox.UniqueID] = true;
        }
        else
        {
            ViewState.Remove(checkbox.UniqueID);
        }
    }
    
    protected void radID_DataBinding(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        checkbox.Checked = ViewState[checkbox.UniqueID] != null;
    }
