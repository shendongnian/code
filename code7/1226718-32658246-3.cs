    protected void chapp_SelectedIndexChanged(object sender, EventArgs e)
    {
       CheckBoxList c = (CheckBoxList)sender;
       var oldSelected = GetValues(true);
       var newSelected = c.Items.Cast<ListItem>()
                            .Where(x => x.Selected)
                            .Select(x => x.Value).ToList();
       var selectedChanged = oldSelected.Except(newSelected);
       ViewState["SelectedValues"] = newSelected;
    
       var oldUnSelected = GetValues(false);
       var newUnSelected = c.Items.Cast<ListItem>()
                            .Where(x => !x.Selected)
                            .Select(x => x.Value).ToList();
       var unSelectedChanged = oldUnSelected.Except(newUnSelected);
       ViewState["UnSelectedValues"] = newUnSelected;
     }
