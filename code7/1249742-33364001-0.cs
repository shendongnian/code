    private bool isAdjusting;
    private void richTextBox1_SelectionChanged(object sender, EventArgs e)
    {
        if (richTextBox1.SelectionFont == null)
            return;
        bool isBold = (richTextBox1.SelectionFont.Style & FontStyle.Bold) == FontStyle.Bold;
        isAdjusting = true;
        btnBold.Checked = isBold;
        menuItemBold.Checked = isBold;
        isAdjusting = false;
    }
    private void btnBold_CheckedChanged(object sender, EventArgs e)
    {
        if (isAdjusting)
            return;
        SetBold(btnBold.Checked);
    }
    private void SetBold(bool bold)
    {
        if (richTextBox1.SelectionFont == null)
            return;
        FontStyle style = richTextBox1.SelectionFont.Style;
        style = bold ? style | FontStyle.Bold : style & ~FontStyle.Bold;
        richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
    }
