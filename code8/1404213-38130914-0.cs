    private void FriendsLb_DrawItem(object sender, DrawItemEventArgs e)
    {
        Bitmap bmp = someBitmap;
        bmp.SetResolution(e.Graphics.DpiX, e.Graphics.DpiY);
        e.DrawBackground();
        e.Graphics.DrawString(yourItemText, someFont, Brushes.Black, 
                              bmp.Width + 5, e.Bounds.Y);  // adapt to you liking
        if (bmp != null)
        {
            FriendsLb.ItemHeight = bmp.Height;  // or a little more..
            e.Graphics.DrawImage(bmp, 0, e.Bounds.Y);
        }
    }
