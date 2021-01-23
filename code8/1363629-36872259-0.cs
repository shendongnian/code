    string selectedTexts="";
    foreach (ListItem item in DropDownList1.Items)
    {
        if (item.Selected)
        {
            selectedTexts += item.Text + " : " + item.Value + "\\n";
        }
    }
    hdnSearchParam.Value= selectedTexts;
