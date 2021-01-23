    Color clickedColor = Color.Empty;
    private void panel4_MouseClick(object sender, MouseEventArgs e)
    {
        using (Bitmap bmp = new Bitmap( panel4.ClientSize.Width, panel4.ClientSize.Height))
        {
            panel4.DrawToBitmap(bmp,panel4.ClientRectangle);
            clickedColor = bmp.GetPixel(e.X, e.Y);
        }
    }
