    protected void btnSeguinte_Click(object sender, EventArgs e)
    {
        List<string> selectedValues = new List<string>();
        foreach(ListViewItem item in lvForm.Items)
        {
            RadioButtonList rb = (RadioButtonList)item.FindControl("rbList");
            // if none are selected, it returns an empty string
            if(rb.SelectedValue.length > 0)
            {
                selectedValues.Add(rb.SelectedValue);
            }
        }
        // do something with your selected values
    }
