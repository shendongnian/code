    private void checkBox1_Paint(object sender, PaintEventArgs e)
    {
        base.OnPaint(e);
        if (!checkBox1.Enabled)
        {
            CheckBox checkbox = sender as CheckBox;
            int x = ClientRectangle.X + CheckBoxRenderer.GetGlyphSize(
                e.Graphics, CheckBoxState.UncheckedNormal).Width + 1;
            int y = ClientRectangle.Y + 1;
            TextRenderer.DrawText(e.Graphics, checkbox.Text, 
                checkbox.Font, new Point(x, y), checkbox.ForeColor, 
                TextFormatFlags.LeftAndRightPadding);
        }
    }
