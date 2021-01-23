    [DllImport("user32")]
    private static extern bool InvalidateRect(IntPtr hwnd, IntPtr rect, bool bErase);
    private void DrawLetter()
    {
        var letter = counter.ToString();
        Graphics g = Graphics.FromHdc(GetDC(IntPtr.Zero));
        float width = ((float)this.ClientRectangle.Width);
        float height = ((float)this.ClientRectangle.Width);
        float emSize = height;
        Font font = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular);
        font = FindBestFitFont(g, letter.ToString(), font, this.ClientRectangle.Size);
        SizeF size = g.MeasureString(letter.ToString(), font);
        // Invalidate all the windows.
        InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
        // Sometimes, the letter is drawn before the windows are invalidated.
        // To fix that, add a small delay before drawing the letter.
        System.Threading.Thread.Sleep(100);
        // Finally, draw the letter.
        g.DrawString(letter, font, new SolidBrush(Color.White), (width - size.Width) / 2, 0);
    }
