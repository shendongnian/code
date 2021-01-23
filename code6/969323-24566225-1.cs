    private void btnClear_Click(object sender, EventArgs e)
    {
        foreach (var ctrl in pnlButtons)
            ctrl.BackColor = Color.LightGray;               
    }
    private void btnFill_Click(object sender, EventArgs e)
    {
        foreach (Control ctrl in pnlButtons)
            ctrl.BackColor = Color.LightBlue;
    }
