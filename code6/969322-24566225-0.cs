    private void btnClear_Click(object sender, EventArgs e)
    {
        foreach (Control ctrl in pnlButtons)
            if (ctrl is Button && ctrl.BackColor == Color.LightBlue)
                ctrl.BackColor = Color.LightGray;               
    }
    private void btnFill_Click(object sender, EventArgs e)
    {
        foreach (Control ctrl in pnlButtons)
            if (ctrl is Button && ctrl.BackColor == Color.LightGray)
                ctrl.BackColor = Color.LightBlue;
    }
