    ddlCommonTasks_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddl = sender as DropDownList;
        PerformIndexChangedAction(ddl);
    }
    private void PerformIndexChangedAction(DropDownList ddl)
    {
        lblTest.Text=ddl.SelectedItem.Text;
    }
