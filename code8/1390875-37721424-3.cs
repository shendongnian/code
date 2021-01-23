    private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
    {
        using (Font font = new Font("Consolas", 11f))
        {
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, font, Brushes.DarkMagenta, e.Bounds);
        }
