    protected void CB1_CheckedChanged(Object sender, EventArgs e)
    {
        CheckBox cb1 = sender as CheckBox;
        Control container = cb1.NamingContainer;
        CheckBox cb2 = container.FindControl("CB2") as CheckBox;
        cb2.Checked = cb1.Checked;
    }
