    Color clickedColor = Color.Empty;
    private void panel_MouseClick(object sender, MouseEventArgs e)
    {
        using (Bitmap bmp = new Bitmap( panel.ClientSize.Width, panel4.ClientSize.Height))
        {
            panel.DrawToBitmap(bmp,panel.ClientRectangle);
            clickedColor = bmp.GetPixel(e.X, e.Y);
        }
    }
