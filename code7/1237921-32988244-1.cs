    protected override void OnPaint(PaintEventArgs e)
    {
        PaintTransparentBackground(this, e);
        // TODO: Paint your actual content here with rounded corners
    }
    private static void PaintTransparentBackground(Control c, PaintEventArgs e)
    {
        if (c.Parent == null || !Application.RenderWithVisualStyles)
            return;
        ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
    }
