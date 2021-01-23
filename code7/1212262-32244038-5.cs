    protected override void OnPaint(PaintEventArgs e)
    {
        // creating a buffered context
        using (BufferedGraphicsContext context = new BufferedGraphicsContext())
        {
            // creating a buffer for the original Graphics
            Rectangle rect = new Rectangle(Point.Empty, Control.ClientSize);
            using (BufferedGraphics bg = context.Allocate(e.Graphics, rect))
            {
                using (PaintEventArgs be = new PaintEventArgs(bg.Graphics, e.ClipRectangle))
                {
                    // Draw your control here onto the buffer
                    DrawUserControl(be.Graphics, rect);
                }
                // copy the buffer onto the original Graphics
                bg.Render(e.Graphics);
            }
        }
    }
