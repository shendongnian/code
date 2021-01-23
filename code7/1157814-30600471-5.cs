    void drawText()
    {
        using (Font font = new Font("Arial", 24f))
        using (Graphics G = Graphics.FromImage(pictureBox1.Image))
        {
            // no anti-aliasing, please
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            G.DrawString("Hello World", font, Brushes.Orange, 123f, 234f);
        }
        pictureBox1.Invalidate();
    }
