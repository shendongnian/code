    private void chbShowLines_CheckedChanged(object sender, EventArgs e)
    {
        panel.Invalidate()
    }
    private void panel_Paint(object sender, PaintEventArgs e)
    {
        if (chbShowLines.Checked)
        {
            // draw lines
        }
        // draw common parts
    }
