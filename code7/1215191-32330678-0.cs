    IntPtr dc = GetWindowDC(Handle);
    using (Graphics g = Graphics.FromHdc(dc))
    {
        // creating a buffered context
        using (BufferedGraphicsContext context = new BufferedGraphicsContext())
        {
            // creating a buffer for the original Graphics
            using (BufferedGraphics bg = context.Allocate(e.Graphics, ClientRectangle))
            {
                 if (mPlaceHolderFont == null)
                    mPlaceHolderFont = new Font(Font, FontStyle.Italic);
                 var gBuf = bg.Graphics;
                 var rect = ClientRectangle;
                 rect.Inflate(-1, -1);
                 gBuf.FillRectangle(Brushes.White, rect);
                 gBuf.DrawString(PlaceHolder, mPlaceHolderFont, sPlaceHolderBrush, rect, sFormat);
                 // copying the buffer onto the original Graphics
                 bg.Render(e.Graphics);
            }
        }
    }
