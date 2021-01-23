    using System.Diagnostics;
    ...
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        Font font = new Font("Arial", 16, FontStyle.Regular, GraphicsUnit.Pixel);
        SizeF sz = g.MeasureString("Text...", font);
        Debug.WriteLine(sz.Width.ToString());
        Debug.WriteLine(sz.Height.ToString());
    }
