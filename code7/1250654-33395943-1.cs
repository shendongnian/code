    protected void btnSubmitLangs_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
          CheckBoxList chkListLanguages = (CheckBoxList)item.FindControl("chkListLangs");
    
          List<ListItem> selectedLangs = chkListLanguages.Items.Cast<ListItem>()
                                         .Where(listItem => listItem.Selected)
                                         .ToList();
          //Or you can use foreach loop also to get the selected items.
        }
    
    }
