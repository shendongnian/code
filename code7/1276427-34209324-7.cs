    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Font font = new Font("Arial", 10);
        string text = "I'm trying to draw a box around a label which has been aligned.";
        Size layout = new Size(100, 0);
            
        Size sz = TextRenderer.MeasureText(e.Graphics, text, font, layout,
                TextFormatFlags.WordBreak);
        Rectangle rc = new Rectangle(new Point(0,0), sz);
        e.Graphics.DrawRectangle(Pens.Black, rc);
        TextRenderer.DrawText(e.Graphics, text, font, rc,
            SystemColors.ControlText, SystemColors.Control, TextFormatFlags.WordBreak);
    }
