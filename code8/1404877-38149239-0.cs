    private void radioHandler(object sender, System.EventArgs e)
    {
        RadioButton rbt = (RadioButton)sender;
        if (rbt.Checked)
        {
            rbt.Checked = false;
            return;
        }
        rbt.Checked = true;
        foreach (RadioButton r in pnl.Controls.OfType<RadioButton>())
            if (r != rbt) r.Checked = false;
    }
