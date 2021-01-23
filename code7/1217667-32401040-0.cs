    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        PaintTransparentBackground(panel1, e);
        using (Brush b = new SolidBrush(Color.FromArgb(128, panel1.BackColor)))
        {
            e.Graphics.FillRectangle(b, e.ClipRectangle);
        }
    }
    private static void PaintTransparentBackground(Control c, PaintEventArgs e)
    {
        if (c.Parent == null || !Application.RenderWithVisualStyles)
            return;
        ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
    }
