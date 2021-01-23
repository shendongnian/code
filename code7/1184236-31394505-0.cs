    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedTab.Tag == null)
        {
            tabControl1.SelectedTab.Tag = true; //set to true so no longer evaluates to null
            MessageBox.Show("You are viewing " + tabControl1.SelectedTab.Name);
        }
        else
        {
            MessageBox.Show("Sorry, can't run twice.");
        }
    }
