    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Insert")
        {
            ListViewItem item = ListView1.InsertItem;
            FormView SectionIDFormView = (FormView)item.FindControl("SectionIDFormView");
            TextBox SectionIDTextBox = (TextBox)SectionIDFormView.FindControl("SectionIDTextBox");
            //Find your other controls
            //Do your insert
        }
    }
