    private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
    {
        // Use the sender, so that you can use the same event handler for every label
        ToolStripStatusLabel label = (ToolStripStatusLabel)sender;
        // Background
        e.Graphics.FillRectangle(new SolidBrush(label.BackColor), e.ClipRectangle);
        // Border
        e.Graphics.DrawRectangle(
            new Pen(label.ForeColor),  // use any Color here for the border
            new Rectangle(e.ClipRectangle.Location,new Size(e.ClipRectangle.Width-1,e.ClipRectangle.Height-1))
        );
        // Draw Text if you need it
        e.Graphics.DrawString(label.Text, label.Font, new SolidBrush(label.ForeColor), e.ClipRectangle.Location);
    }
