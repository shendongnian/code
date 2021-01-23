    private void checkbox_CheckedChanged(object sender, EventArgs e)
    {
        var checkBox = (CheckBox) sender;
        //no need to check bools against true or false, they evaluate themselves
        if (checkBox.Checked) 
        {
            checkBox.Text = "B";
            checkBox.BackColor = Color.Green;
        }
        else
        {
            checkBox.Text = "1";
            checkBox.BackColor = SystemColors.Control;
        }
    }
