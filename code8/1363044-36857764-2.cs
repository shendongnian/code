    private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
    {
        e.DrawBackground();
        e.DrawBorder();
        using (Font f = new Font("Consolas", 8f))
            e.Graphics.DrawString(e.ToolTipText, f, SystemBrushes.ControlText, e.Bounds);
    }
